using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text CoinText;

    private void Awake()
    {
        CoinText = GameObject.Find("Canvas/CoinPanel/CoinText").GetComponent<Text>();
    }

    public IEnumerator UpdateCoins(int coinChange)
    {
        int currentCoin = Int32.Parse(CoinText.text);

        for (int i = 1; i <= 50; i++)
        {
            int newCoin = currentCoin + coinChange * i / 50;
            CoinText.text = newCoin.ToString();
            yield return new WaitForSeconds(0.01F);
        }
    }
}