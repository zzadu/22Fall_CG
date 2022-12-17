using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ImageEffect_Multipass : MonoBehaviour
{
    Shader myShader;
    Material myMaterial;

    void Start()
    {
        myShader = Shader.Find("My/ImageEffect/Multipass");
        myMaterial = new Material(myShader);
    }

    private void OnDisable()
    {
        if (myMaterial)
        {
            DestroyImmediate(myMaterial);
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, myMaterial, 1);
    }
}