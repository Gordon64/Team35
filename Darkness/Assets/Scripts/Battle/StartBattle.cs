using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBattle : MonoBehaviour
{
    public static string previousScene;

    // Start is called before the first frame update
    void Awake()
    {
        previousScene = SceneManager.GetActiveScene().name.ToString();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public string PreviousScene()
    {
        return previousScene;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name != "BattleScene")
        {
            previousScene = scene.name;
        }
    }
}
