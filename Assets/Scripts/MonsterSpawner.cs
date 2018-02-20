using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] Prefabs;

    public bool NeedSpawn = true;

    private ObjectPool op;

    private void Start()
    {
        op = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        if (NeedSpawn)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        var newTransform = transform;
        op.Create(Prefabs[Random.Range(0, Prefabs.Length)], newTransform.position);
        NeedSpawn = false;
    }
}