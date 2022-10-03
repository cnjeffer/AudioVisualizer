using System.Collections;
using System.Collections.Generic;
using Lunity.AudioVis;
using UnityEngine;

public class SphereProperty : MonoBehaviour
{
    public AudioAverageSet Audio;

    public float FrequencyMultiplier = 1f;
    public string PropertyName1;

    public float SpeedMultiplier = 1f;
    public string PropertyName2;

    public Renderer TargetRenderer;

    private float ProgressValue;

    public void Start()
    {
        Audio = gameObject.GetComponent<AudioAverageSet>();
    }
    public void Update()
    {
        ProgressValue = Audio.Pulse * FrequencyMultiplier;
        TargetRenderer.material.SetFloat(PropertyName1, 10 + ProgressValue);

        ProgressValue = Audio.Pulse * SpeedMultiplier;
        TargetRenderer.material.SetFloat(PropertyName2, ProgressValue);
    }
}
