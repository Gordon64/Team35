using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevelButton : MonoBehaviour
{
    public GameObject ExitPanel;
    public GameObject ShopPanel;
    void Start(){
        ExitPanel.gameObject.SetActive(false);
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            UnityEngine.Debug.Log(ExitPanel.gameObject.activeSelf);
            if(ExitPanel.gameObject.activeSelf == false){
                if (ShopPanel.gameObject.activeSelf == false){
                    UnityEngine.Debug.Log(ExitPanel);
                    ExitPanel.gameObject.SetActive(true);
                }
                else if (ShopPanel.gameObject.activeSelf == true){
                    ShopPanel.gameObject.SetActive(false);
                }
            }
            else if(ExitPanel.gameObject.activeSelf == true){
                ExitPanel.gameObject.SetActive(false);
            }
        }
    }
}
