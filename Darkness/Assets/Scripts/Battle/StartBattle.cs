using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBattle : MonoBehaviour
{
    public static GameObject instance;
    public static string previousScene;

    // Start is called before the first frame update
    void Start()
    {
        previousScene = SceneManager.GetActiveScene().name.ToString();

        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = gameObject;
        DontDestroyOnLoad(this.gameObject);

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
