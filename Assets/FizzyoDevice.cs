using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Fizzyo;



public class FizzyoDevice : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        
    }

    public bool isButtonPressed()
    {
        bool buttonPressed = FizzyoFramework.Instance.Device.ButtonDown();
        return buttonPressed;
    }

    public bool isBlow()
    {
        float pressure = FizzyoFramework.Instance.Device.Pressure();
        if (pressure == 0)
        {
            return false;
        }
        return true;
    }
}



