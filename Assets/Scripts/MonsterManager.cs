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
    private GameObject _monster;

    private void Awake()
    {
        //op = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
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
        
        _monster = GameObject.Instantiate(Prefabs[Random.Range(0, Prefabs.Length)]);
        _monster.transform.position = transform.position;
        _monster.transform.parent = transform;
        _monster.GetComponent<Monster>().SetTotalHealth(Random.Range(1000, 4000));
        //var newTransform = transform;
        //Instantiate(Prefabs[Random.Range(0, Prefabs.Length)], newTransform.position, Quaternion.identity);
        
    }

    public void KillMonster()
    {
        GameObject.Destroy(_monster);
        NeedSpawn = true;
    }
}