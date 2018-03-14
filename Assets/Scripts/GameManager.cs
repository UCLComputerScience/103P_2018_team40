using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float DmgBuffer;
    public int CoinNum;
    public double Score;
    public bool LeaderboardViewing;
        
    public MonsterManager Mm;
    public UIManager Um;
    public CharacterManager Cm;
    public BackgroundManager Bm;
    public AudioManager Am;

    // Use this for initialization
    void Awake()
    {
        DmgBuffer = 0;
        Score = 0;
        LeaderboardViewing = false;
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
        if (amount > 0)
        {
            Am.PlayCoinGained();
        }
        else if (amount < 0)
        {
            Am.PlayCoinSpent();
        }

        CoinNum += amount;
        AddScore(Math.Abs(amount));
        StartCoroutine(Um.UpdateCoins(amount));
    }


    public float GetDamage()
    {
        var dmg = DmgBuffer;
        DmgBuffer = 0;
        AddScore(dmg);
        return dmg;
    }

    public void Hit(float dmg)
    {
        Am.PlayHit();
        DmgBuffer += dmg;
        Um.ShowDmg(dmg);
    }

    private void AddScore(double amount)
    {
        Score += amount;
        Um.UpdateScore(Score);
    }

    public void HideForLeaderboard()
    {
        LeaderboardViewing = true;
        ToggleChildrenRenderer(Mm.gameObject, false);
        ToggleChildrenRenderer(GameObject.Find("Canvas/Hitbar"), false);
    }

    public void CloseLeaderboard()
    {
        LeaderboardViewing = false;
        ToggleChildrenRenderer(Mm.gameObject, true);
        ToggleChildrenRenderer(GameObject.Find("Canvas/Hitbar"), true);
    }

    private void ToggleChildrenRenderer(GameObject go, bool enable)
    {
        if (go.gameObject.GetComponent<Renderer>() != null)
        {
            go.GetComponent<Renderer>().enabled = enable;
        }

        foreach (Transform child in go.transform)
        {
            if (child.gameObject.GetComponent<Renderer>() != null)
            {
                child.gameObject.GetComponent<Renderer>().enabled = enable;
            }
        }
    }

    public void ChangeBg()
    {
        Bm.NextBg();
    }

    public void ShowMonsterLv(int lv)
    {
        Um.UpdateMonsterLv(lv);
    }

    public void ShowCombo(int num)
    {
        Um.ShowCombo(num);
    }


}