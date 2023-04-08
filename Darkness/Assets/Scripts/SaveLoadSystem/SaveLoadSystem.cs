using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class SaveLoadSystem : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    public static SaveLoadSystem instance {get; private set;}
    private List<SaveLoadInterface> SaveLoadObjects;
    private SavedInfo gameData;
    private DataFileManager fileManager;
    private string sceneName;

    private void Awake(){
        if (instance != null){
            UnityEngine.Debug.Log("Found more than one Data SaveLoadSystem in the scene, Destroying newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        this.fileManager = new DataFileManager(fileName);
    }

    private void OnEnable(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable(){
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        sceneName = SceneManager.GetActiveScene().name;
        this.SaveLoadObjects = FindAllSaveLoadObjects();
        if(sceneName != "Tutorial" && PlayerPrefs.GetFloat("health", 0) == 0 ){
            LoadGame();
        }
        UnityEngine.Debug.Log("loaded called");
    }

    public void OnApplicationQuit(){
        PlayerPrefs.DeleteAll();
    }

    public void NewGame(){
        this.gameData = new SavedInfo();
        fileManager.Save(gameData);
        LoadGame();
    }

    public void LoadGame(){
        this.gameData = fileManager.Load();
        if (this.gameData == null){
            UnityEngine.Debug.Log("No data found.");
            NewGame();
        }

        foreach (SaveLoadInterface SaveLoadObject in SaveLoadObjects){
            SaveLoadObject.LoadData(gameData);
        }
        UnityEngine.Debug.Log(gameData.health);
    }
    
    public void SaveGame(){
        if(this.gameData != null){
            foreach (SaveLoadInterface SaveLoadObject in SaveLoadObjects){
                UnityEngine.Debug.Log("should be data before " + this.gameData.position);
                SaveLoadObject.SaveData(gameData);
                UnityEngine.Debug.Log("Saved data!");
            }
        }
        UnityEngine.Debug.Log("should be data saved " +this.gameData.position);

        fileManager.Save(gameData);

        UnityEngine.Debug.Log("Data actually saved " + gameData.position);
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
