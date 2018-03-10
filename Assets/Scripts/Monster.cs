using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Vector2 RewardRange;
    public Vector2 HealthRange;

    private MonsterManager _mm;
    private Animator _animator;
    private GameObject _hb;
    public float _totalHealth = 1f;
    public float _currentHealth = 1f;
    private const float FullHealthScale = 1.301246F;

    private void Awake()
    {
        _mm = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
        _hb = GameObject.Find("HealthbarFrame/Healthbar");
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _totalHealth = Random.Range((int) (HealthRange.x * (1 +_mm.MonsterLv * _mm.HealthGrowFactor)),
            (int) (HealthRange.y * (1 + _mm.MonsterLv * _mm.HealthGrowFactor)));
        _currentHealth = _totalHealth;
        SetHealth(1f);
    }

    private void FixedUpdate()
    {
        _currentHealth -= _mm.GetDamage();
        // change animation according to monster health status
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _animator.SetBool("Alive", false);
        }
        else
        {
            _animator.SetBool("Alive", true);
        }
        Debug.Log("current:" + _currentHealth);
        Debug.Log("total:" + _totalHealth);
        SetHealth(_currentHealth / _totalHealth);
    }

    private void SetHealth(float percentage)
    {
        var oldScale = _hb.transform.localScale;
        _hb.transform.localScale = new Vector3(FullHealthScale * percentage, oldScale.y, oldScale.z);
    }

    public int GetReward()
    {
        return Random.Range((int) (RewardRange.x * (1 +_mm.MonsterLv * _mm.RewardGrowFactor)),
            (int) (RewardRange.y * (1 +_mm.MonsterLv * _mm.RewardGrowFactor)));
    }

    public void Die()
    {
        _mm.KillMonster();
    }
}