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

    private MonsterManager _mm;
    private UIManager _ui;
    private CharacterManager _cm;
    private DamageIndicator _di;
    private BackgroundManager _bm;

    // Use this for initialization
    void Awake()
    {
        _mm = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        _cm = GameObject.Find("Canvas/Upgrade/CharacterManager").GetComponent<CharacterManager>();
        _di = GameObject.Find("Canvas/DamageIndicator").GetComponent<DamageIndicator>();
        _bm = GameObject.Find("BackgroundManager").GetComponent<BackgroundManager>();
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
        CoinNum += amount;
        AddScore(Math.Abs(amount));
        StartCoroutine(_ui.UpdateCoins(amount));
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
        DmgBuffer += dmg;
        _di.ShowDmg(dmg);
    }

    public void AddScore(double amount)
    {
        Score += amount;
        _ui.UpdateScore(Score);
    }

    public void HideForLeaderboard()
    {
        ToggleChildrenRenderer(_mm.gameObject, false);
        ToggleChildrenRenderer(GameObject.Find("Canvas/Hitbar"), false);
    }

    public void CloseLeaderboard()
    {
        ToggleChildrenRenderer(_mm.gameObject, true);
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
        _bm.NextBg();
    }

    public void ShowMonsterLv(int lv)
    {
        _ui.UpdateMonsterLv(lv);
    }
}