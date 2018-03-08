﻿/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
//using Microsoft.Xna.Framework.Input;

namespace Fizzyo
{
    public class BreathingDevice : MonoBehaviour
    {

        void Start()
        {
            //Initialise input state
            var inputState = new InputState(this);
            Services.AddService(typeof(InputState), inputState);

            //Initialise the BreathingDevice class
            var fizzyo = new BreathingDevice(this);
            //fizzyo.useRecordedData = true; // Change this value to use actual values instead of recorded data
            Services.AddService(typeof(BreathingDevice), fizzyo);
            var fizzyoDevice = (BreathingDevice)game.Services.GetService(typeof(BreathingDevice));

            //create instance of breath analyser class
            //BreathAnalyser breathAnalyser = new BreathAnalyser(MaxPressure, MaxBreathLength);
            //BreathAnalyser breathAnalyser = new BreathAnalyser(3, 5);
            BreathRecogniser breathRecogniser = new BreathRecogniser(3, 5);

            breathRecogniser.ExhalationComplete += ExhalationCompleteEventHandler;


        }

        // Update is called once per frame
        void Update()
        {

            //2 possible functions for button on breathing device
            bool buttonPresed = BreathingDevice.ButtonDown();
            bool buttonPressed = Fizzyo.BreathingDevice.Instance().ButtonDown();
            //bool isbuttonPresed = Keyboard.GetState().IsKeyDown(Keys.A);


<<<<<<< HEAD
            /*if(buttonPresed == true && pointer on green section of hitbar)
=======
            if (buttonPresed == true && /*pointer on green section of hitbar)
>>>>>>> 89e02b7b1ed47f21154f04454828698346ea4054
            {
                //normal damage
            }*/

<<<<<<< HEAD
            /*if (buttonPresed == true && pointer on yellow section of hitbar)
=======
            if (buttonPresed == true && /*pointer on yellow section of hitbar)
>>>>>>> 89e02b7b1ed47f21154f04454828698346ea4054
            {
                //critical damage
            }*/

            //isBreathGood() function is a part of breath analyser class
            /*if (isBreathGood() == true)
            {
                //rewards
            }*/


            //2 different ways to record pressure
            float pressure = BreathingDevice.Pressure();
            //float pressure = Fizzyo.FizzyoDevice.Instance().Pressure();
            if (pressure == 0)
            {
                //hide hitbar
            }
            else
            {
                //show hitbar
            }

            AddSample(Time.DeltaTime, pressure);

        }

        public bool isButtonPressed()
        {
            return BreathingDevice.ButtonDown();
        }

        public bool isBlow()
        {
            float pressure = BreathingDevice.Pressure();
            if (pressure == 0)
            {
                return false;
            }
            return true;
        }

        public void isGoodBreath()
        {

        }
    }
}
*/
