using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

namespace Fizzyo
{
    public class FizzyoDevice : MonoBehaviour
    {

        void Start()
        {
            //Initialise input state
            var inputState = new InputState(this);
            Services.AddService(typeof(InputState), inputState);

            //Initialise the FizzyoDevice class
            var fizzyo = new FizzyoDevice(this);
            fizzyo.useRecordedData = true; // Change this value to use actual values instead of recorded data
            Services.AddService(typeof(FizzyoDevice), fizzyo);
            var fizzyoDevice = (FizzyoDevice)game.Services.GetService(typeof(FizzyoDevice));

            //create instance of breath analyser class
            //BreathAnalyser breathAnalyser = new BreathAnalyser(MaxPressure, MaxBreathLength);
            BreathAnalyser breathAnalyser = new BreathAnalyser(3, 5);
            BreathRecogniser breathRecogniser = new BreathRecogniser(3, 5);

            breathAnalyser.ExhalationComplete += ExhalationCompleteEventHandler;


        }

        // Update is called once per frame
        void Update()
        {

            //2 possible functions for button on breathing device
            bool buttonPresed = FizzyoDevice.ButtonDown();
            //bool buttonPressed = Fizzyo.FizzyoDevice.Instance().ButtonDown();
            bool isbuttonPresed = Keyboard.GetState().IsKeyDown(Keys.A);


            if (buttonPresed == true && /*pointer on green section of hitbar*/)
            {
                //normal damage
            }

            if (buttonPresed == true && /*pointer on yellow section of hitbar*/)
            {
                //critical damage
            }

            //isBreathGood() function is a part of breath analyser class
            if (isBreathGood() == true)
            {
                //rewards
            }


            //2 different ways to record pressure
            float pressure = FizzyoDevice.Pressure();
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
            return FizzyoDevice.ButtonDown();
        }

        public bool isBlow()
        {
            float pressure = FizzyoDevice.Pressure();
            if (pressure == 0)
            {
                return false;
            }
            return true;
        }

        public bool isGoodBreath()
        {

        }
    }
}

