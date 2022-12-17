using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class SceneChange : MonoBehaviour
{
    public Object loadingScene;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (loadingScene.name == "Heaven")
                SceneManager.LoadScene(loadingScene.name); // 점프해서 하늘로 올라가는 설정
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(loadingScene.name);
    }
}
