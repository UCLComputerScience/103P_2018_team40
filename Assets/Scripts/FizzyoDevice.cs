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

    public bool isBlow() 
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

    public void OnBreathEnded(object sender, ExhalationCompleteEventArgs e)
    {
        bool good = e.IsBreathFull;
        float breath = e.ExhaledVolume;
        if(good == true)
        {
            goodBreath(true);
        }
        if(good == false)
        {
            badBreath(false);
        }

    }



    public bool goodBreath(bool s)
    {
        if(s == true)
        {
            return true; //this means there is a good breath
        }
        return false; //not a good breath
            
    }

    public bool badBreath(bool r)
    {
        if(r == false)
        {
            return true; //this means there is a bad breath
        }
        return false; //not a bad breath
    }










    /*public bool goodBreath(ExhalationCompleteEventArgs e)
    {
        if(good == true)
        {
            return true;
        }

        else
        {
            return false;
        }
            
    }*/
   
    /*public bool badBreath(ExhalationCompleteEventArgs e)
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


    }*/
}



