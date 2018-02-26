using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public int TotalConstantDmg = 0;
    public List<GameObject> Characters;

    private GameManager _gm;

    // Use this for initialization
    void Awake()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        foreach (var ch in Characters)
        {
            TotalConstantDmg += ch.GetComponent<Character>().Dps;
        }

        Debug.Log(TotalConstantDmg);
    }

    public bool TrySpendingCoins(int amount)
    {
        if (!_gm.HasEnoughCoin(amount))
        {
            return false;
        }

        _gm.ChangeCoinNum(-amount);
        return true;
    }

    public void IncreaseConstantDmg(int change)
    {
        TotalConstantDmg += change;
    }
}