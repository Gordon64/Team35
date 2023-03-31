using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevelButton : MonoBehaviour
{
    public GameObject ExitPanel;
    void Start(){
        ExitPanel.gameObject.SetActive(false);
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            UnityEngine.Debug.Log(ExitPanel.gameObject.activeSelf);
            if(ExitPanel.gameObject.activeSelf == false){
                UnityEngine.Debug.Log(ExitPanel);
                ExitPanel.gameObject.SetActive(true);
            }
            else if(ExitPanel.gameObject.activeSelf == true){
                ExitPanel.gameObject.SetActive(false);
            }
        }
    }
}
