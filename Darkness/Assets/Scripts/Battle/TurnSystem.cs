using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class TurnSystem : MonoBehaviour
{
    public List<UnitStats> unitsStats;

    public GameObject enemyEncounter;

    [SerializeField]
    private GameObject actionsMenu, enemyUnitsMenu;

    private GameObject playerParty;

    public List<GameObject> enemyUnits, remainingEnemyUnits;

    SavePlayerPos playerPosData;

    ShowVictoryDefeat screen;

    void Start()
    {
        playerPosData = FindObjectOfType<SavePlayerPos>();
        screen = FindObjectOfType<ShowVictoryDefeat>();

        //Finds Player units, adds to turn list
        unitsStats = new List<UnitStats>();
        GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");

        foreach(GameObject playerUnit in playerUnits)
        {
            UnitStats currentUnitStats = playerUnit.GetComponent<UnitStats>();
            currentUnitStats.calculateNextActTurn(0);
            unitsStats.Add(currentUnitStats);
        }

        //Find Enemy units, adds to turn 

        //GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
        enemyUnits = new List<GameObject>(GameObject.FindGameObjectsWithTag("EnemyUnit"));

        foreach (GameObject enemyUnit in enemyUnits)
        {
            UnitStats currentUnitStats = enemyUnit.GetComponent<UnitStats>();
            currentUnitStats.calculateNextActTurn(0);
            unitsStats.Add(currentUnitStats);
        }

        //Sorts units by turn order
        unitsStats.Sort();

        if(actionsMenu != null && enemyUnitsMenu != null)
        {
            this.actionsMenu.SetActive(false);
            this.enemyUnitsMenu.SetActive(false);
        }

        this.nextTurn();
    }

    public void nextTurn()
    {
        //end conditions, no enemies or no players

        //GameObject[] remainingEnemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
        remainingEnemyUnits = new List<GameObject>(GameObject.FindGameObjectsWithTag("EnemyUnit"));
        GameObject[] remainingPlayerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");

        if (remainingEnemyUnits.Count == 0)
        {
            playerPosData.PlayerPosLoad();
            enemyEncounter.GetComponent<CollectReward>().collectReward();
            foreach(GameObject unit in remainingPlayerUnits)
            {
                unit.GetComponent<UnitStats>().cleanStats();
            }

            StartCoroutine(EndScreen(false));
        }


        if(remainingPlayerUnits.Length == 0)
        {
            StartCoroutine(EndScreen(true));
            //Send to main menu for loss? Then, they can load?
        }

        //Top of turn list is popped, popped unit takes their turn
        UnitStats currentUnitStats = unitsStats[0];
        unitsStats.Remove(currentUnitStats);
        GameObject playerParty = GameObject.Find("PlayerParty");

        if (!currentUnitStats.isDead())
        {
            GameObject currentUnit = currentUnitStats.gameObject;

            foreach(var x in unitsStats)
            {
                //Debug.Log(x.ToString());
            }

            //recalculates the current unit's next turn
            currentUnitStats.calculateNextActTurn(currentUnitStats.nextActTurn);
            unitsStats.Add(currentUnitStats);
            unitsStats.Sort();

            currentUnitStats.GetComponent<UnitStats>().ProcessStatusEffects();

            if (currentUnit.tag == "PlayerUnit")
            {
                Debug.Log("Player Turn");
                if(playerParty != null)
                {
                    playerParty.GetComponent<SelectUnit>().selectCurrentUnit(currentUnit.gameObject);
                }
            }
            else
            {
                Debug.Log("Enemy Turn");
                currentUnit.GetComponent<EnemyUnitAction>().act();
            }
        }
        else
        {
            this.nextTurn();
        }
    }

    IEnumerator EndScreen(bool lost)
    {
        if (lost)
        {
            screen.ShowDefeatScreen();
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("Start Screen");
        }
        else if (!lost)
        {
            screen.ShowVictoryScreen();
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(StartBattle.previousScene);
        }
    }
}
