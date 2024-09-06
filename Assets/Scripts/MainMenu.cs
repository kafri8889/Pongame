using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Application.platform == RuntimePlatform.WebGLPlayer && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void PlaySinglePlayer() {
        GlobalVariable.Set("mode", "single");
        SceneManager.LoadScene(1);
    }

    public void PlayMultiPlayer() {
        GlobalVariable.Set("mode", "duo");
        SceneManager.LoadScene(1);
    }
}
