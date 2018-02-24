using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private MonsterManager _mm;
    private GameObject _hb;

    private int TotalHealth = 1;

    public int CurrentHealth = 1;
    public const float FullHealthScale = 1.301246F;

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
            Debug.Log("Killing Monster");
            CurrentHealth = 0;
            _mm.KillMonster();
        }

        Debug.Log("Current Health is: " + CurrentHealth);
        //Debug.Log("Percentage is: " + (float) CurrentHealth / (float) TotalHealth);
        SetHealth((float) CurrentHealth / TotalHealth);
    }

    private void SetHealth(float percentage)
    {
        var oldScale = _hb.transform.localScale;
        _hb.transform.localScale = new Vector3(FullHealthScale * percentage, oldScale.y, oldScale.z);
    }
}