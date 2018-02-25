using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private MonsterManager _mm;
    private UIHandler _ui;

    // Use this for initialization
    void Awake()
    {
        _mm = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
        _ui = GameObject.Find("Canvas").GetComponent<UIHandler>();
    }

    public bool TrySpendingCoins(int amount)
    {
        if (!_ui.HasEnoughCoin(amount))
        {
            return false;
        }

        StartCoroutine(_ui.UpdateCoins(-amount));
        return true;
    }
}