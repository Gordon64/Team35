using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SaveLoadSystem : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    public static SaveLoadSystem instance {get; private set;}
    private List<SaveLoadInterface> SaveLoadObjects;
    private SavedInfo gameData;
    private DataFileManager fileManager;

    private void Awake(){
        if (instance != null){
            UnityEngine.Debug.Log("Found more than one Data SaveLoadSystem in the scene");
        }
        instance = this;
    }

    private void Start(){
        this.fileManager = new DataFileManager(fileName);
        this.SaveLoadObjects = FindAllSaveLoadObjects();
        LoadGame();
    }


    public void NewGame(){
        this.gameData = new SavedInfo();
    }

    public void LoadGame(){
        this.gameData = fileManager.Load();
        if (this.gameData == null){
            UnityEngine.Debug.Log("No data found.");
        }

        foreach (SaveLoadInterface SaveLoadObject in SaveLoadObjects){
            SaveLoadObject.LoadData(gameData);
        }
        UnityEngine.Debug.Log(gameData.health);
    }
    
    public void SaveGame(){
        if(this.gameData != null){
            foreach (SaveLoadInterface SaveLoadObject in SaveLoadObjects){
                SaveLoadObject.SaveData(gameData);
            }
        }

        fileManager.Save(gameData);
    }

    public void LoadGameAction(){
        LoadGame();
    }

    public void SaveGameAction(){
        SaveGame();
    }

    private List<SaveLoadInterface> FindAllSaveLoadObjects(){
        IEnumerable<SaveLoadInterface> SaveLoadObjects = FindObjectsOfType<MonoBehaviour>().OfType<SaveLoadInterface>();
        return new List<SaveLoadInterface>(SaveLoadObjects);
    }
}
