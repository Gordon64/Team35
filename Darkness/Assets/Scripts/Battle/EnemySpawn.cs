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
    EnemyManager enemyData;

    //Spawns an encounter when a player enters the spawner range and changes the scene.
    void Start()
    {
        playerPosData = FindObjectOfType<SavePlayerPos>();
        enemyData = FindObjectOfType<EnemyManager>();
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
        if(scene.name == "LevelScene"){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerPosData.PlayerPosSave();
            this.spawning = true;
            enemyData.defeatedEnemy(this.gameObject.name);
            SceneManager.LoadScene("BattleScene");
        }
        else if(other.gameObject.tag == "Weapon")
        {
            playerPosData.PlayerPosSave();
            this.spawning = true;
            this.hurt = true;
            enemyData.defeatedEnemy(this.gameObject.name);
            SceneManager.LoadScene("BattleScene");
        }
    }

}
