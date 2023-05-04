using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneName : MonoBehaviour
{
    public string sceneName = "";
    /*
    void OnEnable()
    {
        SceneManager.LoadScene("TransitionLevel1", LoadSceneMode.Single);
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartNewGame.instance.TransitionCheck = true;
            Bandit.Instance.Nextlevel();
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }

    }
}
