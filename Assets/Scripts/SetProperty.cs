using System.Collections;
using System.Collections.Generic;
using Lunity.AudioVis;
using UnityEngine;

public class SetProperty : MonoBehaviour
{

    public float ColorMultiplier = 1f;
    public AudioAverageSet Audio;

    public string PropertyName1;
    public Color startColor1;
    public Color endColor1;

    public string PropertyName2;
    public Color startColor2;
    public Color endColor2;

    public string PropertyName3;
    public float EdgePercent = -1f;

    public Renderer TargetRenderer;

    private Color fade1;
    private Color fade2;

    private float ColorValue;
    private float ProgressValue;
    private float negative;

    public void Start()
    {
        Audio = FindObjectOfType<AudioAverageSet>();
    }

    public void Update()
    {
        ColorValue = Audio.Pulse * ColorMultiplier;

        negative = -Mathf.Abs(Audio.Pulse * ColorMultiplier);

        fade1 = Color.LerpUnclamped(startColor1, endColor1, ColorValue);
        fade2 = Color.LerpUnclamped(startColor2, endColor2, ColorValue);
        EdgePercent += Audio.Pulse;

        TargetRenderer.material.SetColor(PropertyName1, fade1);
        TargetRenderer.material.SetColor(PropertyName2, fade2);
        TargetRenderer.material.SetFloat(PropertyName3, EdgePercent);
    }
}
