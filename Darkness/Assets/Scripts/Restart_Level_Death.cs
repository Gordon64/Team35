using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_Level_Death : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        UnityEngine.Debug.Log("death");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
