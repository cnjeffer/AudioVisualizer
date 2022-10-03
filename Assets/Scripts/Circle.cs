using System.Collections;
using System.Collections.Generic;
using Lunity.AudioVis;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [Header("Config")]
    public Transform Target;
    public AudioAverageSet Audio;

    float timeCounter = 0;

    [Header("Variables")]
    public float MinScale = 1;
    public float MaxScale = 7;
    public float MaxSpeed = 10;
    public float SmoothTime = 1f;
    public float distance = 4;
    public float buffer = -0.5f;

    public float multiplier = 1;
    float value = 0;

    private Vector3 _velocity;

    public void Start()
    {
        Audio = gameObject.GetComponent<AudioAverageSet>();
    }
    public void Update()
    {
        // Creates a simple circle motion that is manipualted by the audio on where in the circle it should be. Creating a really neat and spuratic movement.

        timeCounter += Time.deltaTime * Random.Range(1, 10); //Randomly sets the cubes time on circle, if you want all cubes to line up like a snake set this to 1
        value = Audio.Pulse * multiplier;

        float x = Target.position.x + Mathf.Cos(timeCounter) * (value * distance);
        float y = Target.position.y + (MinScale * Mathf.Clamp(value, buffer, MaxScale)); 
        float z = Target.position.z + Mathf.Sin(timeCounter) * (value * distance);


        transform.position = new Vector3(x, y, z);
    }
}