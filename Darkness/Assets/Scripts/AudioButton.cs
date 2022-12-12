using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioButton : MonoBehaviour
{
    public void ShowAudio(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
