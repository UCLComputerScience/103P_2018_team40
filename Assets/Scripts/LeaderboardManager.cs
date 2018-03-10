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

    private GameManager _gm;
    private string _name = "Default";

    private string _conSting = "user id=bcf74a4a937449;"
                               + "password=fb35064177cf9e0;"
//                               + "Trusted_Connection=yes;"
                               + "database=arduinocoursework;"
                               + "connection timeout=15;"
                               + "Server=eu-cdbr-azure-west-b.cloudapp.net";


    private void Awake()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Use this for initialization
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
//        SqlConnection dbcon = new SqlConnection(_conSting);
//        try
//        {
//            dbcon.Open();
//            Debug.Log("Connection successful");    
//            
//            var dbcom = new SqlCommand("SELECT rank, score, name "
//                                       + "FROM scoreboard "
//                                       + "ORDER BY rank", dbcon);
//            var dbReader = dbcom.ExecuteReader();
//            for (int i = 1; i < 4; i++)
//            {
//                if (dbReader.Read())
//                {
//                    var en = Instantiate(EntryPrefab);
//                    en.transform.SetParent(transform, false);
//                    var pos = en.transform.localPosition;
//                    pos.y = EntryStartingY - (i - 1) * EntryYSpacing;
//                    en.transform.localPosition = pos;
//                    en.GetComponent<Entry>().SetEntry(dbReader["rank"].ToString(), dbReader["score"].ToString(),
//                        dbReader["name"].ToString());
//                }
//            }
//        }
//        catch (Exception e)
//        {
//            Debug.Log("Connection Error!");
//            Debug.Log(e.ToString());
//        }
        var web = new WWW("https://fizzyogaming6.azurewebsites.net/");
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

    public void GetName()
    {
        _name = NameInputField.GetComponent<InputField>().text;
        _name = _name == "" ? "Default" : _name;
    }
}