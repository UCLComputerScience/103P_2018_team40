using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject[] Prefabs;
    public GameManager Gm;
    public int MonsterLv;
    public float HealthGrowFactor;
    public float RewardGrowFactor;
    public bool NeedSpawn = true;

    private Monster _monster;

    void FixedUpdate()
    {
        if (NeedSpawn)
        {
            SpawnEnemy();
        }
    }

    public float GetDamage()
    {
        return Gm.GetDamage();
    }

    private void SpawnEnemy()
    {
        var go = GameObject.Instantiate(Prefabs[Random.Range(0, Prefabs.Length)]);
//        go.transform.position = transform.position;
        go.transform.SetParent(transform, false);
        _monster = go.GetComponent<Monster>();
        NeedSpawn = false;
        //var newTransform = transform;
        //Instantiate(Prefabs[Random.Range(0, Prefabs.Length)], newTransform.position, Quaternion.identity);
    }

    public void KillMonster()
    {
        MonsterLv += 1;
        Gm.ShowMonsterLv(MonsterLv);
        // Change bg every ten monsters
        if (MonsterLv % 10 == 0)
        {
            Gm.ChangeBg();
        }
        NeedSpawn = true;
        Gm.ChangeCoinNum(_monster.GetReward());
        GameObject.Destroy(_monster.gameObject);
    }
}