using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int LoopNum;
    
    private Text _coinText;
    private GameManager _gm;

    private void Awake()
    {
        _coinText = GameObject.Find("Canvas/CoinPanel/CoinText").GetComponent<Text>();
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        _coinText.text = _gm.CoinNum.ToString();
    }

    public IEnumerator UpdateCoins(int coinChange)
    {

        for (int i = 1; i <= LoopNum; i++)
        {
            int newCoin = _gm.CoinNum + coinChange * i / LoopNum;
            _coinText.text = newCoin.ToString();
            yield return new WaitForSeconds(0.01F);
        }
    }
}