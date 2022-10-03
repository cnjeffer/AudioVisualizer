using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lunity.AudioVis
{

    //A simple component to visualize the raw audio data coming out of SoundCapture
    public class AudioCube : MonoBehaviour
    {
        [Header("Config")]
        public AudioAverageSet Audio;

        [Header("Variables")]
        [Tooltip("1 = Pulse, 2 - Vibe, 3 = Flicker")] public int Mode;
        public float MinScale = 0.1f;
        public float MaxScale = 10f;
        public float multiplier = 18f;
        public float buffer = -0.5f;


        float value;

        public void Start()
        {
            Audio = gameObject.GetComponent<AudioAverageSet>();
        }
    
        public void Update()
        {
            if (Mode == 1)
            {
                value = (Audio.Pulse * multiplier);
            }

            if (Mode == 2)
            {
                value = (Audio.Vibe * multiplier);
            }

            if (Mode == 3)
            {
                value = ( Audio.Flicker * multiplier);
            }

            transform.localScale = new Vector3(transform.localScale.x, MinScale + Mathf.Clamp(value, buffer, MaxScale), transform.localScale.z); ;
        }
    }
}