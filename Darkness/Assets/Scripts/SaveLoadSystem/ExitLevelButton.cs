using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevelButton : MonoBehaviour
{
    public GameObject ExitPanel;
    public GameObject ShopPanel;
    public GameObject DialoguePanel;
    public GameObject DialoguePanel2;

    void Start(){
        ExitPanel.gameObject.SetActive(false);
    }


    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            UnityEngine.Debug.Log(ExitPanel.gameObject.activeSelf);
            if(ExitPanel.gameObject.activeSelf == false){
                if(ShopPanel != null){
                    if (ShopPanel.gameObject.activeSelf == false){
                        UnityEngine.Debug.Log(ExitPanel);
                        ExitPanel.gameObject.SetActive(true);
                        Bandit.Instance.shopEnabled = true;
                        Bandit.Instance.rb2d.velocity = Vector2.zero;
                    }
                    else if (ShopPanel.gameObject.activeSelf == true){
                        ShopPanel.gameObject.SetActive(false);
                        Bandit.Instance.shopEnabled = false;
                    }
                }
                else if(DialoguePanel != null){
                    if (DialoguePanel.gameObject.activeSelf == false){
                        UnityEngine.Debug.Log(ExitPanel);
                        ExitPanel.gameObject.SetActive(true);
                        Bandit.Instance.shopEnabled = true;
                        Bandit.Instance.rb2d.velocity = Vector2.zero;
                    }
                    else if (DialoguePanel.gameObject.activeSelf == true){
                        DialoguePanel.gameObject.SetActive(false);
                        Bandit.Instance.shopEnabled = false;
                    }
                }
                else if(DialoguePanel2 != null){
                    if (DialoguePanel2.gameObject.activeSelf == false){
                        UnityEngine.Debug.Log(ExitPanel);
                        ExitPanel.gameObject.SetActive(true);
                        Bandit.Instance.shopEnabled = true;
                        Bandit.Instance.rb2d.velocity = Vector2.zero;
                    }
                    else if (DialoguePanel2.gameObject.activeSelf == true){
                        DialoguePanel2.gameObject.SetActive(false);
                        Bandit.Instance.shopEnabled = false;
                    }
                }
            }
            else if(ExitPanel.gameObject.activeSelf == true){
                ExitPanel.gameObject.SetActive(false);
                Bandit.Instance.shopEnabled = false;
            }
        }

        if(ExitPanel.activeSelf == false){
            Bandit.Instance.shopEnabled = false;
        }
    }
}
