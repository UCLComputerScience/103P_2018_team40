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
    public GameObject ErrorText;
    public GameObject InvalidNameText;
    public float EntryStartingY;
    public float EntryYSpacing;
    public const string PhpUrl = "https://fizzyogaming6.azurewebsites.net";

    private GameManager _gm;
    private string _name = "Default";


    private void Awake()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        _gm.HideForLeaderboard();
        gameObject.SetActive(true);
        ErrorText.SetActive(false);
        InvalidNameText.SetActive(false);
        StartCoroutine(DisplayEntries());
    }

    private void DestoryEntries()
    {
        foreach (Transform en in transform)
        {
            if (en.name.StartsWith("Entry(Clone)"))
            {
                Destroy(en.gameObject);
            }
        }
    }

    private IEnumerator DisplayEntries()
    {
        //yield return new WaitForSeconds(0.1f); // give enough time for insertion to apply
        // destory all previous entries
        DestoryEntries();
        
        // query db through php website
        var web = new WWW(PhpUrl);
        yield return web;
        if (web.text == "" || web.text.StartsWith("Connection failed"))
        {
            DisplayError("Connection Failed!");
        }
        else if (web.text.StartsWith("Query failed"))
        {
            DisplayError("Query Failed!");
        }
        else
        {
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
                en.GetComponent<Entry>().SetEntry((i + 1).ToString(), fields[0],
                    fields[1]);
                if (i >= 5)
                {
                    break;
                }
            }
        }
    }

    public void Upload()
    {
        _name = NameInputField.GetComponent<InputField>().text;
        _name = _name == "" ? "Default" : _name;
        if (_name.Contains(";") || _name.Contains("\\"))
        {
            InvalidNameText.SetActive(true);
            return;
        }
        var form = new WWWForm();
        form.AddField("score", (int) _gm.Score);
        form.AddField("name", _name);
        var www = new WWW(PhpUrl, form);
        InvalidNameText.SetActive(false);
        
        StartCoroutine(WaitForInsertion(www));
    }

    private IEnumerator WaitForInsertion(WWW w)
    {
        yield return w;
        StartCoroutine(DisplayEntries());
    }

    private void DisplayError(string msg)
    {
        ErrorText.SetActive(true);
        ErrorText.GetComponent<Text>().text = msg;
    }

    public void Close()
    {
        DestoryEntries();
        _gm.CloseLeaderboard();
        Destroy(gameObject);
    }
}