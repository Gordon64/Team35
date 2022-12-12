using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayButton : MonoBehaviour
{

    public void ShowDisplay(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
