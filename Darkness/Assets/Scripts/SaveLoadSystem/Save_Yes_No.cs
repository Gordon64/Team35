using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save_Yes_No : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void YesButton(string sceneName){
        SaveLoadSystem.instance.SaveGame();
        SceneManager.LoadScene(sceneName);
    }

    public void NoButton(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
