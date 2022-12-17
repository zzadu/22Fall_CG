using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject ui;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            ui.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.U))
        {
            ui.SetActive(false);
        }
    }
}
