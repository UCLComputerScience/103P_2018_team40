using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Character : MonoBehaviour
{
    public float Power;
    public int Lv;
    public float PowerGrow;
    public int CostGrow;
    public int RoundTo;
    private Text _lvText;
    private Text _powerText;
    private Text _costText;
    private CharacterManager _cm;
    private List<Power> _powerComponents = new List<Power>();

    // Use this for initialization
    void Awake()
    {
        _lvText = gameObject.transform.Find("TextLv/Lv").gameObject.GetComponent<Text>();
        _powerText = gameObject.transform.Find("TextPower/Power").gameObject.GetComponent<Text>();
        _costText = gameObject.transform.Find("ButtonUpgrade/LvupCoins").gameObject.GetComponent<Text>();
        _cm = GameObject.Find("CharacterManager").GetComponent<CharacterManager>();
        foreach (var component in GetComponents<MonoBehaviour>())
        {
            if (component is Power)
            {
                _powerComponents.Add(component as Power);
            }
        }
    }

    private void Start()
    {
        _lvText.text = Lv.ToString();
        _powerText.text = Power.ToString();
    }

    public void Upgrade()
    {
        int cost = Int32.Parse(_costText.text);
        var ifEnough = _cm.TrySpendingCoins(cost);
        if (!ifEnough)
        {
            return; // don't have enough coins
        }

        Lv += 1;
        Power += PowerGrow;
        Power = (float) Math.Round(Power, RoundTo);
        cost += CostGrow;
        foreach (var power in _powerComponents)
        {
            power.Upgrade();
        }

        _lvText.text = Lv.ToString();
        _powerText.text = Power.ToString();
        _costText.text = cost.ToString();
    }
}