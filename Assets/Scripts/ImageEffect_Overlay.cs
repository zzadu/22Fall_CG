using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ImageEffect_Overlay : MonoBehaviour
{
    Shader myShader;
    Material myMaterial;

    public Texture2D blendTex;
    public float opacity = 1f;

    void Start()
    {
        myShader = Shader.Find("My/ImageEffect/Overlay");
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
        opacity = Mathf.Clamp(opacity, 0f, 1f);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        myMaterial.SetFloat("_Opacity", opacity);
        myMaterial.SetTexture("_BlendTex", blendTex);
        Graphics.Blit(source, destination, myMaterial);
    }
}