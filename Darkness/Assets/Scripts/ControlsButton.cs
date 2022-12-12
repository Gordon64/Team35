using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void ShowControls(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
