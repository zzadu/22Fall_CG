using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    public Transform[] PosReference;
    public Text[] text;
    Camera TargetCamera;

    void Start()
    {
        TargetCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        for (int i = 0; i < PosReference.Length; i++)
        {
            text[i].text = PosReference[i].name;
        }
    }

    private void Update()
    {
        DisplayAtPoint();
    }

    void DisplayAtPoint()
    {
        for (int i = 0; i < PosReference.Length; i++)
        {
            Vector3 WorldPos = PosReference[i].position + Vector3.up;
            Vector2 ScreenPos = TargetCamera.WorldToScreenPoint(WorldPos);

            text[i].transform.position = ScreenPos;
        }
    }
}