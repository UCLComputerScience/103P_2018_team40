using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject[] BgPrefabs;
    private GameObject _currentBg;
    private int _counter;

    private void Start()
    {
        _currentBg = Instantiate(BgPrefabs[_counter++]);
        _currentBg.transform.SetParent(transform, false);
    }

    public void NextBg()
    {
        if (_counter >= BgPrefabs.Length)
        {
            _counter = 0; // reset counter
        }
        Destroy(_currentBg);
        _currentBg = Instantiate(BgPrefabs[_counter++]);
        _currentBg.transform.SetParent(transform, false);
    }
}