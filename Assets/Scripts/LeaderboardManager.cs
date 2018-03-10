using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    public GameObject EntryPrefab;
    public GameObject NameInputField;
    public float EntryStartingY;
    public float EntryYSpacing;
    public const string PhpUrl = "https://fizzyogaming6.azurewebsites.net/";

    private GameManager _gm;
    private string _name = "Default";



    private void Awake()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        _gm.HideForLeaderboard();
        gameObject.SetActive(true);
        StartCoroutine(DisplayEntries());
    }

    public IEnumerator DisplayEntries()
    {
        var web = new WWW(PhpUrl);
        yield return web;
        string[] entries = web.text.Split('\\');
        Debug.Log(web.text);
        for (int i = 0; i < entries.Length - 1; i++)
        {
            string[] fields = entries[i].Split(';');

            var en = Instantiate(EntryPrefab);
            en.transform.SetParent(transform, false);
            var pos = en.transform.localPosition;
            pos.y = EntryStartingY - i * EntryYSpacing;
            en.transform.localPosition = pos;
            en.GetComponent<Entry>().SetEntry(fields[0], fields[1],
                fields[2]);
            if (i >= 5)
            {
                break;
            }
        }
    }

    public void Upload()
    {
        _name = NameInputField.GetComponent<InputField>().text;
        _name = _name == "" ? "Default" : _name;
        var form = new WWWForm();
        form.AddField("rank",1);
        form.AddField("score",(int)_gm.Score);
        form.AddField("name",_name);
        
        var www = new WWW(PhpUrl,form);
        StartCoroutine(CheckWWW(www));

    }

    private IEnumerator CheckWWW(WWW w)
    {
        yield return w;
        Debug.Log(w.text);
    }
}