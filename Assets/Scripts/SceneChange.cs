using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class SceneChange : MonoBehaviour
{
    public Object loadingScene;
    public Object upScene;
    public Object downScene;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (upScene != null)
            {
                SceneManager.LoadScene(upScene.name);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (upScene != null)
            {
                SceneManager.LoadScene(downScene.name);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(loadingScene.name);
    }
}
