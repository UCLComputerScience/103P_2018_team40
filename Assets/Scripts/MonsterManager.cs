using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject[] Prefabs;
    public bool NeedSpawn = true;

    private Monster _monster;
    private GameManager _gm;

    private void Awake()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        if (NeedSpawn)
        {
            SpawnEnemy();
        }
    }

    public float GetDamage()
    {
        return _gm.GetDamage();
    }

    private void SpawnEnemy()
    {
        var go = GameObject.Instantiate(Prefabs[Random.Range(0, Prefabs.Length)]);
        go.transform.position = transform.position;
        go.transform.parent = transform;
        _monster = go.GetComponent<Monster>();
        NeedSpawn = false;
        //var newTransform = transform;
        //Instantiate(Prefabs[Random.Range(0, Prefabs.Length)], newTransform.position, Quaternion.identity);
    }

    public void KillMonster()
    {
        NeedSpawn = true;
        _gm.ChangeCoinNum(_monster.GetReward());
        GameObject.Destroy(_monster.gameObject);
    }
}