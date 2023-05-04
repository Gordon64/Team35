using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNewGame : MonoBehaviour
{
    public static StartNewGame instance {get; private set;}
    public bool StartCheck;
    public bool BattleCheck = false;
    public bool TransitionCheck = false;
    public Stack<string> sceneStack = new Stack<string>();
    private void Awake(){
        if(instance != null){
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        StartCheck = false;
    }

    void Update(){
        if(SceneManager.GetActiveScene().name == "BattleScene")
            BattleCheck = true;
        else if(SceneManager.GetActiveScene().name == "Start Screen")
            PlayerPrefs.DeleteAll();

        if(!sceneStack.Contains(SceneManager.GetActiveScene().name) && !sceneStack.Contains("Tutorial"))
            sceneStack.Push(SceneManager.GetActiveScene().name);
    }

    public void LoadCorrectScene(){
        string name = "";
        try{
            name = SaveLoadSystem.instance.gameData.LastScene;
        }
        catch{
            //not working
        }

        if(name == "Level2Scene" || name == "Level3Scene"){
            SceneManager.LoadScene(name);
        }
        else{
            SceneManager.LoadScene("LevelScene");
        }
    }
}
