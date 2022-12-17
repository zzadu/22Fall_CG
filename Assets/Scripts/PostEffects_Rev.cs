using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PostEffects_Rev : MonoBehaviour
{

    Shader myShader;
    Material myMaterial;
    // Start is called before the first frame update
    void Start()
    {
        myShader = Shader.Find("My/PostEffects/Rev");
        myMaterial = new Material(myShader);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, myMaterial, 0);
    }
    private void OnDisable()
    {
        //카메라 비활성화시 호출되는 이벤트임
        if (myMaterial) 
        { DestroyImmediate(myMaterial); 
        
        }
        

    }
}
