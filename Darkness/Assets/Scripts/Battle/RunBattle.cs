using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunBattle : MonoBehaviour
{
    [SerializeField] private string runAway = "LevelScene";

    public void RunButton()
    {
        SceneManager.LoadScene(runAway);
    }
}
