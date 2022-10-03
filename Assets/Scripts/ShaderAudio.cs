using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lunity.AudioVis
{

    //A simple component to visualize the raw audio data coming out of SoundCapture
    public class ShaderAudio : MonoBehaviour
    {
        public AudioAverageSet Audio;
        public SoundCapture.DataSource Target = SoundCapture.DataSource.AverageVolume;
        public int BandIndex;

        private SoundCapture _sc;

        Shader shader1;
        Shader shader2;
        Renderer rend;

        public void Awake()
        {
            _sc = FindObjectOfType<SoundCapture>();
            rend = GetComponent<Renderer>();
            shader1 = Shader.Find("_Color1");
        }

        public void Update()
        {
            rend.material.shader = shader1;
        }



        private float GetValue()
        {
            switch (Target)
            {
                case SoundCapture.DataSource.AverageVolume:
                    return _sc.AverageVolume;
                case SoundCapture.DataSource.PeakVolume:
                    return _sc.PeakVolume;
                case SoundCapture.DataSource.SingleBand:
                    return _sc.BarData[Mathf.Clamp(BandIndex, 0, _sc.BarData.Length)];
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}