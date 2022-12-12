using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class TurnSystem : MonoBehaviour
{
    private List<UnitStats> unitsStats;

    [SerializeField]
    private GameObject actionsMenu, enemyUnitsMenu;

    private GameObject playerParty;

    void Start()
    {
        unitsStats = new List<UnitStats>();
        GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");

        foreach(GameObject playerUnit in playerUnits)
        {
            UnitStats currentUnitStats = playerUnit.GetComponent<UnitStats>();
            currentUnitStats.calculateNextActTurn(0);
            unitsStats.Add(currentUnitStats);
        }

        GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");

        foreach(GameObject enemyUnit in enemyUnits)
        {
            UnitStats currentUnitStats = enemyUnit.GetComponent<UnitStats>();
            currentUnitStats.calculateNextActTurn(0);
            unitsStats.Add(currentUnitStats);
        }

        unitsStats.Sort();

        this.actionsMenu.SetActive(false);
        this.enemyUnitsMenu.SetActive(false);

        this.nextTurn();
    }

    public void nextTurn()
    {
        GameObject[] remainingEnemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");

        if(remainingEnemyUnits.Length == 0)
        {
            SceneManager.LoadScene("LevelScene");
        }

        GameObject[] remainingPlayerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");

        if(remainingPlayerUnits.Length == 0)
        {
            SceneManager.LoadScene("LevelScene");
        }

        UnitStats currentUnitStats = unitsStats[0];
        unitsStats.Remove(currentUnitStats);
        GameObject playerParty = GameObject.Find("PlayerParty");
        Debug.Log("running");

        if (!currentUnitStats.isDead())
        {
            GameObject currentUnit = currentUnitStats.gameObject;

            foreach(var x in unitsStats)
            {
                Debug.Log(x.ToString());
            }

            currentUnitStats.calculateNextActTurn(currentUnitStats.nextActTurn);
            unitsStats.Add(currentUnitStats);
            unitsStats.Sort();
            if(currentUnit.tag == "PlayerUnit")
            {
                playerParty.GetComponent<SelectUnit>().selectCurrentUnit(currentUnit.gameObject);
            }
            else
            {
                currentUnit.GetComponent<EnemyUnitAction>().act();
            }
        }
        else
        {
            this.nextTurn();
        }
    }
}
