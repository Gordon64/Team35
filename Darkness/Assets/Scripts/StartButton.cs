using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    public void StartLevel(string sceneName)
    {
        SaveLoadSystem.instance.NewGame();
        SceneManager.LoadScene(sceneName);
    }
}
