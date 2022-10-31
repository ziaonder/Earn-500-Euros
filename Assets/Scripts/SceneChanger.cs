using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Scene 2")
            Counter.Instance.OnTimeElapse += Scene3;
        if (currentScene.name == "Scene 3")
            ResultScript.Instance.OnSceneChange += Scene4;
    }

    public void Scene1()
    {
        SceneManager.LoadScene("Scene 1");
    }
    public void Scene2()
    {
        SceneManager.LoadScene("Scene 2");
    }

    public void Scene3()
    {
        SceneManager.LoadScene("Scene 3");
    }

    public void Scene4()
    {
        SceneManager.LoadScene("Scene 4");
    }
}
