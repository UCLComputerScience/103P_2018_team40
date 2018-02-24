using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    private Text _coinText;

    private void Awake()
    {
        _coinText = GameObject.Find("Canvas/CoinPanel/CoinText").GetComponent<Text>();
    }

    public void UpdateCoins(int coinChange)
    {
        int newCoin = Int32.Parse(_coinText.text) + coinChange;
        _coinText.text = newCoin.ToString();
    }
}