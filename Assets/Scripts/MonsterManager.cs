using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject[] Prefabs;
    public int ConstantDamage = 10;
    public bool NeedSpawn = true;
    public int SpawnDelay = 3;

    //private ObjectPool op;
    private Monster _monster;
    private UIHandler _ui;

    private void Awake()
    {
        //op = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
        _ui = GameObject.Find("Canvas").GetComponent<UIHandler>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (NeedSpawn)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    public int GetDamage()
    {
        return ConstantDamage; // + Hitbar.GetDamage()
    }

    private IEnumerator SpawnEnemy()
    {
        NeedSpawn = false;
        yield return new WaitForSeconds(SpawnDelay);

        var go = GameObject.Instantiate(Prefabs[Random.Range(0, Prefabs.Length)]);
        go.transform.position = transform.position;
        go.transform.parent = transform;
        _monster = go.GetComponent<Monster>();
        _monster.SetTotalHealth(Random.Range(1000, 4000));
        //var newTransform = transform;
        //Instantiate(Prefabs[Random.Range(0, Prefabs.Length)], newTransform.position, Quaternion.identity);
    }

    public void KillMonster()
    {
        NeedSpawn = true;
        StartCoroutine(_ui.UpdateCoins(_monster.GetReward()));
        GameObject.Destroy(_monster.gameObject);
    }
}