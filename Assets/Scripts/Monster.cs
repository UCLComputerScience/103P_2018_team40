using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public const float FullHealthScale = 1.301246F;
    public Vector2 RewardRange;
    public Vector2 HealthRange;

    private MonsterManager _mm;
    private Animator _animator;
    private GameObject _hb;
    private float _totalHealth = 1f;
    private float _currentHealth = 1f;

    private void Awake()
    {
        _mm = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
        _hb = GameObject.Find("HealthbarFrame/Healthbar");
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _totalHealth = Random.Range((int) HealthRange.x, (int) HealthRange.y);
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

        SetHealth(_currentHealth / _totalHealth);
    }

    private void SetHealth(float percentage)
    {
        var oldScale = _hb.transform.localScale;
        _hb.transform.localScale = new Vector3(FullHealthScale * percentage, oldScale.y, oldScale.z);
    }

    public int GetReward()
    {
        return Random.Range((int) RewardRange.x, (int) RewardRange.y);
    }

    public void Die()
    {
        _mm.KillMonster();
    }
}