using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevelButton : MonoBehaviour
{
    public void ReturnToStart(string sceneName)
    {
        SaveLoadSystem.instance.SaveGame();
        UnityEngine.Debug.Log("Gamer Save");
        SceneManager.LoadScene(sceneName);
    }
}
