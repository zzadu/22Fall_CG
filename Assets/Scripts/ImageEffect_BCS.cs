using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ImageEffect_BCS : MonoBehaviour
{
    Shader myShader;
    Material myMaterial;

    public float brightness = 1f;
    public float saturation = 1f;
    public float contrast = 1f;

    void Start()
    {
        myShader = Shader.Find("My/ImageEffect/BCS");
        myMaterial = new Material(myShader);
    }

    private void OnDisable()
    {
        if (myMaterial)
        {
            DestroyImmediate(myMaterial);
        }
    }

    private void Update()
    {
        brightness = Mathf.Clamp(brightness, 0, 3);
        saturation = Mathf.Clamp(saturation, 0, 3);
        contrast = Mathf.Clamp(contrast, 0, 3);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        myMaterial.SetFloat("_Brightness", brightness);
        myMaterial.SetFloat("_Saturation", saturation);
        myMaterial.SetFloat("_Contrast", contrast);
        Graphics.Blit(source, destination, myMaterial);
    }
}