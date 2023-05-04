using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBattle : MonoBehaviour
{
    private static GameObject instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = gameObject;
        DontDestroyOnLoad(this.gameObject);
    }
}
