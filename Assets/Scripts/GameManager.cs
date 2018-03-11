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

    public MonsterManager Mm;
    public UIManager Ui;
    public CharacterManager Cm;
    public DamageIndicator Di;
    public BackgroundManager Bm;
    public AudioManager Am;

    // Use this for initialization
    void Awake()
    {
//        _mm = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
//        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
//        _cm = GameObject.Find("Canvas/Upgrade/CharacterManager").GetComponent<CharacterManager>();
//        _di = GameObject.Find("Canvas/DamageIndicator").GetComponent<DamageIndicator>();
//        _bm = GameObject.Find("BackgroundManager").GetComponent<BackgroundManager>();
        DmgBuffer = 0;
        Score = 0;
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
        StartCoroutine(Ui.UpdateCoins(amount));
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
        Di.ShowDmg(dmg);
    }

    private void AddScore(double amount)
    {
        Score += amount;
        Ui.UpdateScore(Score);
    }

    public void HideForLeaderboard()
    {
        ToggleChildrenRenderer(Mm.gameObject, false);
        ToggleChildrenRenderer(GameObject.Find("Canvas/Hitbar"), false);
    }

    public void CloseLeaderboard()
    {
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
        Ui.UpdateMonsterLv(lv);
    }

//    public void PlayCoinGained()
//    {
//        Am.PlayCoinGained();
//    }
//
//    public void PlayCoinSpent()
//    {
//        Am.PlayCoinSpent();
//    }
//
//    public void PlayHit()
//    {
//        Am.PlayHit();
//    }
}