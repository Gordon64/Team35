using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyEncounterPrefab;

    private bool spawning = false;
    private bool hurt = false;

    SavePlayerPos playerPosData;

    //Spawns an encounter when a player enters the spawner range and changes the scene.
    void Start()
    {
        playerPosData = FindObjectOfType<SavePlayerPos>();
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "BattleScene")
        {
            if (this.spawning)
            {
                Instantiate(enemyEncounterPrefab);
                if (this.hurt)
                {
                    GameObject enemyUnit = GameObject.FindGameObjectWithTag("EnemyUnit");
                    UnitStats currentUnitStats = enemyUnit.GetComponent<UnitStats>();
                    currentUnitStats.health -= 5;
                }
            }

            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerPosData.PlayerPosSave();
            this.spawning = true;
            if(UnitStats.instance != null){
                UnityEngine.Debug.Log("Instance of UnitStats is not null");
                UnitStats.instance.SetTempValues();
            }
            SceneManager.LoadScene("BattleScene");
        }
        else if(other.gameObject.tag == "Weapon")
        {
            playerPosData.PlayerPosSave();
            this.spawning = true;
            this.hurt = true;
            SceneManager.LoadScene("BattleScene");
        }
    }

}
