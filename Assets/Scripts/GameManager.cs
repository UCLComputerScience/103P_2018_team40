using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int DmgBuffer;
    public int HitbarDmgUpgrade;
    private MonsterManager _mm;
    private UIManager _ui;
    private CharacterManager _cm;

    // Use this for initialization
    void Awake()
    {
        _mm = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        _cm = GameObject.Find("Canvas/Upgrade/CharacterManager").GetComponent<CharacterManager>();
        DmgBuffer = 0;
        HitbarDmgUpgrade = 0;
    }

    public bool HasEnoughCoin(int amount)
    {
        int coin = Int32.Parse(_ui.CoinText.text);
        if (coin >= amount)
        {
            return true;
        }

        return false;
    }

    public void ChangeCoinNum(int amount)
    {
        StartCoroutine(_ui.UpdateCoins(amount));
    }


    public int GetDamage()
    {
        var dmg = DmgBuffer;
        DmgBuffer = 0;
        return dmg; 
    }
}