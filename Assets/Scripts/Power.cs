using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Power : MonoBehaviour {

    protected Character _character;
    protected GameManager _gm;

    public void Awake()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _character = gameObject.GetComponent<Character>();
    }

    public abstract void Upgrade();
}
