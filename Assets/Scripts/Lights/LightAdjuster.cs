using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lunity.AudioVis
{
    //A simple component to visualize the raw audio data coming out of SoundCapture
    public class LightAdjuster : MonoBehaviour
    {
        public Light myLight;
        //private SoundCapture _sc;
        public AudioAverageSet Audio;

        //Range Variable
        public bool changeAngle = false;
        public float angleValue = 0.01f;
        public float minAngle = 25f;
        public float maxAngle = 50f;
    

        //Intensity Variables
        public bool changeIntensity = true;
        public float intensityValue = 4f;
        public float minIntensity = 7f;
        public float maxIntensity = 15f;

        //Color Variables
        public bool changeColors = false;
        public float colorValue = 1f;
        public Color startColor;
        public Color endColor;

        public SoundCapture.DataSource Target = SoundCapture.DataSource.AverageVolume;
        public int BandIndex = 0;

        public float MinScale = 0.1f;
        public float ScaleAmount = 1f;

        public void Start()
        {
            Audio = gameObject.GetComponent<AudioAverageSet>();
        }

        public void Update()
        {
            if (changeAngle)
            {
                myLight.spotAngle = Mathf.PingPong(minAngle + (Audio.Pulse * angleValue), maxAngle);
            }

            if(changeIntensity)
            {
                myLight.intensity = Mathf.PingPong(minIntensity + (Audio.Pulse * intensityValue), maxIntensity);
            }

            if(changeColors)
            {
                float t = Audio.Pulse * colorValue;

                    myLight.color = Color.LerpUnclamped(startColor, endColor, t);
                
            }
        }

    }
}