using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public const float FullHealthScale = 1.301246F;
    public int RewardUpperBound;
    public int RewardLowerBound;

    private MonsterManager _mm;
    private GameObject _hb;
    private int TotalHealth = 1;
    private int CurrentHealth = 1;

    private void Awake()
    {
        _mm = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
        _hb = GameObject.Find("HealthbarFrame/Healthbar");
    }


    public void SetTotalHealth(int th)
    {
        TotalHealth = th;
        CurrentHealth = th;
    }

    private void FixedUpdate()
    {
        CurrentHealth -= _mm.GetDamage();
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            _mm.KillMonster();
        }

        SetHealth((float) CurrentHealth / TotalHealth);
    }

    private void SetHealth(float percentage)
    {
        var oldScale = _hb.transform.localScale;
        _hb.transform.localScale = new Vector3(FullHealthScale * percentage, oldScale.y, oldScale.z);
    }

    public int GetReward()
    {
        return Random.Range(RewardLowerBound, RewardUpperBound);
    }
}