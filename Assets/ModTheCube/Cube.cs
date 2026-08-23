using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    //Transform setting
    public Vector3 spawnPosition = new Vector3(3, 4, 1);
    public Vector3 cubeScale = Vector3.one * 2.5f;

    //Rotation setting
    public Vector3 RotationSpeed = new Vector3(20.0f, 60.0f, 10.0f);

    //Color setting
    public Color baseColor = new Color(0.2f, 06f, 1.0f, 0.8f);
    public bool enableColorShift = true;
    public float colorChangeSpeed = 1.5f;

    private Material material;

    
    void Start()
    {
        //  Change Initial Position & Scale
        transform.position = spawnPosition;
        transform.localScale = cubeScale;
        
        //  Set Material & Initial Color
        material = Renderer.material;
        material.color = baseColor;
    }
    
    void Update()
    {
        //  Rotate over time
        transform.Rotate(RotationSpeed * Time.deltaTime);

        if (enableColorShift && material != null)
        {
            float r = Mathf.PingPong(Time.time * colorChangeSpeed, 1.0f);
            float g = Mathf.PingPong(Time.time * colorChangeSpeed * 0.5f, 1.0f);
            float b = Mathf.PingPong(Time.time * colorChangeSpeed * 0.25f, 1.0f);
            
            material.color = new Color(r, g, b, baseColor.a);
        }
    }
}