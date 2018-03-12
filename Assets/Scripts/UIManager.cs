using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int LoopNum;
    public GameObject LeaderboardPrefab;
    public DamageIndicator Di;
    public ComboIndicator Ci;
    public Text CoinText;
    public Text ScoreText;
    public Text MonsterLvText;
    public GameManager Gm;

    private void Start()
    {
        CoinText.text = Gm.CoinNum.ToString();
    }

    public IEnumerator UpdateCoins(int coinChange)
    {
        for (int i = 1; i <= LoopNum; i++)
        {
            int newCoin = Gm.CoinNum - coinChange * (LoopNum - i) / LoopNum;
            CoinText.text = newCoin.ToString();
            yield return new WaitForSeconds(0.01F);
        }

        int finalCoinNum = Gm.CoinNum;
        CoinText.text = finalCoinNum.ToString();
    }

    public void UpdateScore(double newScore)
    {
        ScoreText.text = Math.Round(newScore,0).ToString().PadLeft(11,'0');
    }

    public void UpdateMonsterLv(int newLv)
    {
        MonsterLvText.text = newLv.ToString();
    }

    public void ShowLeaderboard()
    {
        var lb = Instantiate(LeaderboardPrefab);
        lb.transform.SetParent(transform,false);
    }

    public void ShowDmg(float dmg)
    {
        Di.ShowDmg(dmg);
    }

    public void ShowCombo(int num)
    {
        Ci.UpdateCombo(num);
    }
}