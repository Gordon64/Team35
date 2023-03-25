using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevelButton : MonoBehaviour
{
    public void ReturnToStart(string sceneName)
    {
        SaveLoadSystem.instance.SaveGame();
        SceneManager.LoadScene(sceneName);
    }
}
