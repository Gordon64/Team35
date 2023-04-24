using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel1 : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("LevelScene", LoadSceneMode.Single);
    }
}
