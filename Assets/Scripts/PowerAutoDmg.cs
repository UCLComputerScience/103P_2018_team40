using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerAutoDmg : Power
{
	// Update is called once per frame
	public override void Upgrade () {
	}

	private void FixedUpdate()
	{
		_gm.DmgBuffer += (int)_character.Power;
	}
}
