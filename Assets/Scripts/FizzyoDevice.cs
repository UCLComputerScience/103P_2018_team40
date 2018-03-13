using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Fizzyo;



public class FizzyoDevice : MonoBehaviour
{

    void Start()
    {
        FizzyoFramework.Instance.Recogniser.BreathStarted += OnBreathStarted;
        FizzyoFramework.Instance.Recogniser.BreathComplete += OnBreathEnded;
    }

    private void FixedUpdate()
    {
        Debug.Log("Pressure is: "+ FizzyoFramework.Instance.Device.Pressure());
    }

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

    /*public bool goodBreath(object sender, ExhalationCompleteEventArgs e)
    {
        //FizzyoFramework.Instance.Device.Recogniser.IsBreathFull();
        if(e.IsBreathFull() == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }*/

    /*public bool OnBreathEnded(object sender, ExhalationCompleteEventArgs e)
    {
        //FizzyoFramework.Instance.Device.Recogniser.IsBreathFull();
        if (e.IsBreathFull() == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }*/

   
    void OnBreathStarted(object sender)
    {

    }

    void OnBreathEnded(object sender, ExhalationCompleteEventArgs e)
    {
        

    }


    public bool goodBreath(ExhalationCompleteEventArgs e)
    {
        bool good = e.IsBreathFull;
        if(good == true)
        {
            return true;
        }
        float breath = e.ExhaledVolume;
        if(breath == 0)
        {
            return false;
        }
        else
        {
            return false;
        }
            
    }
   
    public bool badBreath(ExhalationCompleteEventArgs e)
    {
        bool good = e.IsBreathFull;
        if (good == false)
        {
            return true;
        }
        float breath = e.ExhaledVolume;
        if (breath == 0)
        {
            return false;
        }
        else
        {
            return false;
        }


    }
}



