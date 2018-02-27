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
    private Animator _animator;
    private GameObject _hb;
    private int _totalHealth = 1;
    private int _currentHealth = 1;

    private void Awake()
    {
        _mm = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
        _hb = GameObject.Find("HealthbarFrame/Healthbar");
        _animator = GetComponent<Animator>();
    }


    public void SetTotalHealth(int th)
    {
        _totalHealth = th;
        _currentHealth = th;
    }

    private void FixedUpdate()
    {
        _currentHealth -= _mm.GetDamage();
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _animator.SetBool("Alive", false);
        }
        else
        {
            _animator.SetBool("Alive", true);
        }

        SetHealth((float) _currentHealth / _totalHealth);
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

    public void Die()
    {
        _mm.KillMonster();
    }
}