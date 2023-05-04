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
    public string initialScene;

    //Spawns an encounter when a player enters the spawner range and changes the scene.
    void Start()
    {
        playerPosData = FindObjectOfType<SavePlayerPos>();
        enemyData = FindObjectOfType<EnemyManager>();
        SceneManager.sceneLoaded += OnSceneLoaded;

        //saves variable for the scene the spawner is meant to be in
        if(initialScene != null)
        {
            initialScene = SceneManager.GetActiveScene().name;
        }

    }

    private void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        try{
            gameObject.SetActive(true);
        }catch{
            UnityEngine.Debug.Log("Game Object Not Loadable");
        }
        if (scene.name == "BattleScene")
        {
            if (this.spawning)
            {
                //Passing this spawner as a reference, so it can set it's respective spawner as dead once the encounter is won.
                GameObject encounter = Instantiate(enemyEncounterPrefab);
                encounter.GetComponent<CollectReward>().spawner = this.gameObject;

                if (this.hurt)
                {
                    GameObject enemyUnit = GameObject.FindGameObjectWithTag("EnemyUnit");
                    UnitStats currentUnitStats = enemyUnit.GetComponent<UnitStats>();
                    currentUnitStats.health -= 5;
                }

                SceneManager.sceneLoaded -= OnSceneLoaded;
            }

            //Deactivates all spawners in the battle scene.
            gameObject.SetActive(false);
        }
        else if (scene.name != initialScene)
        {
            //destroys the gameobjects for levels besides their initial level
            try{
            Destroy(gameObject);
            }
            catch{
                UnityEngine.Debug.Log("Not able to destroy because game Objects dont exist");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerPosData.PlayerPosSave();
            this.spawning = true;
            //enemyData.defeatedEnemy(this.gameObject.name);
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

    //IEnumerator BattleScene()
    //{
    //    TransitionLoader transition = FindObjectOfType<TransitionLoader>();
    //    transition.StartTransition();
    //    yield return new WaitForSeconds(transition.transitionTime);
    //    SceneManager.LoadScene("BattleScene")
    //}
}
