using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunBattle : MonoBehaviour
{
    [SerializeField] private string runAwayTo = "LevelScene";

    public void RunButton()
    {
        UnitStats.instance.SetTempValues();
        UnityEngine.Debug.Log("health during run: " + UnitStats.instance.health);
        SceneManager.LoadScene(runAwayTo);
    }
}
