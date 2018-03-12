﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameManager Gm;

    // Use this for initialization

    public bool TrySpendingCoins(int amount)
    {
        if (!Gm.HasEnoughCoin(amount))
        {
            return false;
        }

        Gm.ChangeCoinNum(-amount);
        return true;
    }
}