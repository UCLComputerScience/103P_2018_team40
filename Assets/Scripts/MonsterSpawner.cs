using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] Prefabs;

    public bool NeedSpawn = true;

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
        Instantiate(Prefabs[Random.Range(0, Prefabs.Length)], newTransform.position, Quaternion.identity);
        NeedSpawn = false;
    }
}