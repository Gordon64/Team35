using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    public void StartLevel(string sceneName)
    {
        try{
            SaveLoadSystem.instance.NewGame();
        }
        catch{
            UnityEngine.Debug.Log("Can't load yet.");
        }
        SceneManager.LoadScene(sceneName);
    }
}
