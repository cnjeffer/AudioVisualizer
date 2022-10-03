using System.Collections;
using System.Collections.Generic;
using Lunity.AudioVis;
using UnityEngine;

public class ComputeShaderAttractor : MonoBehaviour
{
    [Header("Config")]
    public ComputeShaderSystem ShaderSystem;
    public AudioAverageSet Audio;
    [Tooltip("Right Click to attract to mouse Pos, Left Click to disable")] public bool Control = false;
    
    [Header("Variables")]
    [Tooltip("Chill = 10, Pumpin = 20, Chaos = 50")]  public float MaxForce = 10f;
    [Tooltip("Higher the value the more chaotic horizontal movement becomes")] public float xValue = 10f;
    [Tooltip("Higher the value the more chaotic vertical movement becomes")] public float yValue = 10f;
    public float DistanceFromCamera = -10f;
   

    [Header("Colors")] //Colours...
    [Tooltip("The rate at which color values change")] public float ColorValue = 5f;
    public Color startColor1;
    public Color endColor1;

    private Camera _camera;
    private GameObject newObj;
    private Color fade1;
    private float Distance = 5f;

    public void Awake()
    {
        _camera = Camera.main;
        //debug (enable also in BasicMove() function)
        //newObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
    }


    public void Start()
    {
        Audio = gameObject.GetComponent<AudioAverageSet>();
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Control = true;
            MaxForce = 100f;
        }

        if(Input.GetMouseButtonDown(0) && Control == true)
        {
            Control = false;
            MaxForce = 50f;
        }


        if (Control)
        {
            var mousePos = Input.mousePosition;
            mousePos.z = Distance;
            var position = _camera.ScreenToWorldPoint(mousePos);
            ShaderSystem.AttractorPosition = position;
            ShaderSystem.AttractorStrength = (Audio.Flicker * MaxForce) + 10f;
        }
        else
        {
            BasicMove();
        }

        fade1 = Color.LerpUnclamped(startColor1, endColor1, Audio.Pulse * ColorValue);
        ShaderSystem.Colour = fade1;

    }

    public void BasicMove()
    {
        float x = DistanceFromCamera + (Audio.Pulse * xValue);
        float y = Audio.Vibe * yValue;
        float z = -DistanceFromCamera + (Audio.Pulse * xValue);
        var position = new Vector3(x, y, -z);

        ShaderSystem.AttractorPosition = position;
        ShaderSystem.AttractorStrength = MaxForce; //Movement of the position adds a better effect than adding audio to this option

        //Debug
        //newObj.transform.localPosition = position;
       
        
    }
}
