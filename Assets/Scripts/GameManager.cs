using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float DmgBuffer;
    public int CoinNum;
    
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
    }

    public bool HasEnoughCoin(int amount)
    {
        if (CoinNum >= amount)
        {
            return true;
        }
        return false;
    }

    public void ChangeCoinNum(int amount)
    {
        CoinNum += amount;
        StartCoroutine(_ui.UpdateCoins(amount));
    }


    public float GetDamage()
    {
        var dmg = DmgBuffer;
        DmgBuffer = 0;
        return dmg; 
    }
}