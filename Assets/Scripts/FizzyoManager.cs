using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Fizzyo;

// class adapted from the example on https://github.com/Fizzyo/FizzyoFramework-Unity
public class FizzyoManager : MonoBehaviour
{
    void Start()
    {
        FizzyoFramework.Instance.Recogniser.BreathComplete += OnBreathEnded;
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


    public void OnBreathEnded(object sender, ExhalationCompleteEventArgs e)
    {
        if (e.IsBreathFull)
        {
            Debug.Log("Detected a good breath");
        }
    }
}