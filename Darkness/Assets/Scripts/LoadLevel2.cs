using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel2 : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Level2Scene", LoadSceneMode.Single);
    }
}
