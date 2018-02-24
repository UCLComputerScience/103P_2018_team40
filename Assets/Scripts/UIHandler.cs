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

    public IEnumerator UpdateCoins(int coinChange)
    {
        int currentCoin = Int32.Parse(_coinText.text);
        
        for (int i = 1; i <= 50; i++)
        {
            int newCoin = currentCoin + coinChange * i / 50;
            _coinText.text = newCoin.ToString();
            yield return new WaitForSeconds(0.01F);
        }
    }
}