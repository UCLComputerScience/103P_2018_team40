using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerIncreaseGreenBlock : Power
{
    private Hitbar _hb;

    public new void Awake()
    {
        base.Awake();
        _hb = GameObject.Find("Canvas/Hitbar").GetComponent<Hitbar>();
    }

    private void Start()
    {
        _hb.HBRangeMultiplier = 1 + _character.Power;
    }

    public override void Upgrade()
    {
        _hb.HBRangeMultiplier = 1 + _character.Power;
    }
}