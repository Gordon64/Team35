using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEnding : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("EndingScene", LoadSceneMode.Single);
    }
}
