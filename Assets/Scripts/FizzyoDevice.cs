using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Fizzyo;



public class FizzyoDevice : MonoBehaviour
{
    public bool isButtonPressed() // working fine
    {
        bool buttonPressed = FizzyoFramework.Instance.Device.ButtonDown();
        Debug.Log("Button Pressed is: " + buttonPressed);
        return buttonPressed;
    }

    public bool isBlow() // TODO: Fix it
    {
        float pressure = FizzyoFramework.Instance.Device.Pressure();
        if (pressure == 0)
        {
            return false;
        }
        return true;
    }
}



