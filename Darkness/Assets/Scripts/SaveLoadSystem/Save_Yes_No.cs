using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Save_Yes_No : MonoBehaviour
{ 

    private GameObject myObject;
    private GameObject myObject2;
    // Start is called before the first frame update
    void Start()
    {
        myObject = GameObject.Find("ExitPanel");
        myObject2 = GameObject.Find("SavePanel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void YesButton(string sceneName){
        SaveLoadSystem.instance.SaveGame();
        SceneManager.LoadScene(sceneName);
        PlayerPrefs.DeleteAll();
    }

    public void NoButton(string sceneName){
        SceneManager.LoadScene(sceneName);
        PlayerPrefs.DeleteAll();
    }

    public void TutYesButton(string scenename){
        SceneManager.LoadScene(scenename);
    }
    
    public void TutNobutton(){
        if(myObject != null)
            myObject.SetActive(false);
    }
    
    public void SaveAndContinue(){
        SaveLoadSystem.instance.SaveGame();
        myObject.SetActive(false);
    }

    public void SaveNo(){
        myObject2.SetActive(false);
    }

    public void SaveYes(){
        myObject2.SetActive(false);
        SaveLoadSystem.instance.SaveGame();
    }
}
