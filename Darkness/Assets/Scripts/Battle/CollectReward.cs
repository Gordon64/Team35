using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectReward : MonoBehaviour
{
    [SerializeField]
    private int currency;

    public void Start()
    {
        GameObject turnsystem = GameObject.Find("TurnSystem");
        turnsystem.GetComponent<TurnSystem>().enemyEncounter = this.gameObject;
    }

    public void collectReward()
    {
        GameObject[] livingPlayerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");

        foreach (GameObject playerUnit in livingPlayerUnits)
        {
            playerUnit.GetComponent<UnitStats>().receiveCurrency(currency);
        }

        Destroy(this.gameObject);
    }

}
