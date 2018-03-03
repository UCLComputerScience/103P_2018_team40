using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PowerHitbarDmg : Power
{
    private Hitbar _hb;

    public new void Awake()
    {
        base.Awake();
        _hb = GameObject.Find("Canvas/Hitbar").GetComponent<Hitbar>();
    }

    private void Start()
    {
        _hb.DmgAdds = _character.Power;
    }

    public override void Upgrade()
    {
        _hb.DmgAdds = _character.Power;
        Debug.Log(_hb.DmgAdds);
    }


}