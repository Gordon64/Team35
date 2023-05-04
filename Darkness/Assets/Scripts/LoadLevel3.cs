using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel3 : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Level3Scene", LoadSceneMode.Single);
    }
}
