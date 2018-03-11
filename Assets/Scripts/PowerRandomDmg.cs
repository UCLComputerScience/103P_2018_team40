using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerRandomDmg : Power
{
    private Hitbar _hb;

    public new void Awake()
    {
        base.Awake();
        _hb = GameObject.Find("Canvas/Hitbar").GetComponent<Hitbar>();
    }

    public override void Upgrade()
    {
        _hb.RandomDmgRange.x = 1 - _character.Power;
        if (_character.Power >= 1)
        {
            _hb.RandomDmgRange.x = 0;
        }

        _hb.RandomDmgRange.y = 1 + _character.Power;
    }
}