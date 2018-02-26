using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject[] Prefabs;
    public bool NeedSpawn = true;
    public int SpawnDelay = 3;

    private Monster _monster;
    private GameManager _gm;

    private void Awake()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        return _gm.GetDamage();
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
        _gm.ChangeCoinNum(_monster.GetReward());
        GameObject.Destroy(_monster.gameObject);
    }
}