using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int Dps;
    public int Lv;
    public int DpsGrow;
    public int CostGrow;
    private Text _lvText;
    private Text _dpsText;
    private Text _costText;
    private CharacterManager _cm;

    // Use this for initialization
    void Awake()
    {
        _lvText = gameObject.transform.Find("Lv").gameObject.GetComponent<Text>();
        _dpsText = gameObject.transform.Find("Dps").gameObject.GetComponent<Text>();
        _costText = gameObject.transform.Find("ButtonUpgrade/LvupCoins").gameObject.GetComponent<Text>();
        _cm = GameObject.Find("CharacterManager").GetComponent<CharacterManager>();
    }


    public void Upgrade()
    {
        Debug.Log(_costText.text);
        int cost = Int32.Parse(_costText.text);
        var ifEnough = _cm.TrySpendingCoins(cost);
        if (!ifEnough)
        {
            return; // don't have enough coins
        }

        Lv += 1;
        Dps += DpsGrow;
        cost += CostGrow;
        _cm.IncreaseConstantDmg(DpsGrow);

        _lvText.text = "Current Lv: " + Lv;
        _dpsText.text = "Current DPS: " + Dps;
        _costText.text = cost.ToString();
    }
}