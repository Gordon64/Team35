using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateEnemyMenuItems : MonoBehaviour
{
    [SerializeField]
    private GameObject targetEnemyUnitPrefab;

    [SerializeField]
    private GameObject healthBar;

    [SerializeField]
    private Sprite menuItemSprite;

    [SerializeField]
    private Vector2 initialPosition, itemDimensions;

    [SerializeField]
    private KillEnemy killEnemyScript;

    //Creates Buttons for targeting the Enemy.
    void Awake()
    {
        GameObject enemyUnitsMenu = GameObject.Find("EnemyUnitsMenu");
        GameObject enemyUnitsInfo = GameObject.Find("EnemyUnitsInfo");

        GameObject[] existingItems = GameObject.FindGameObjectsWithTag("TargetEnemyUnit");
        Vector2 nextPosition = new Vector2(this.initialPosition.x + (existingItems.Length * this.itemDimensions.x), this.initialPosition.y);

        GameObject targetEnemyUnit = Instantiate(this.targetEnemyUnitPrefab, enemyUnitsMenu.transform) as GameObject;
        targetEnemyUnit.name = "Target" + this.gameObject.name;
        targetEnemyUnit.transform.localPosition = nextPosition;
        targetEnemyUnit.transform.localScale = this.gameObject.transform.localScale;
        targetEnemyUnit.GetComponent<Button>().onClick.AddListener(() => selectEnemyTarget());
        targetEnemyUnit.GetComponent<Image>().sprite = this.menuItemSprite;

        GameObject enemyHealth = Instantiate(this.healthBar, enemyUnitsInfo.transform) as GameObject;
        enemyHealth.GetComponentInChildren<ShowUnitHealth>().changeUnit(this.gameObject);

        killEnemyScript.menuItem = targetEnemyUnit;
        killEnemyScript.health = enemyHealth;
    }
    
    //Targets Enemy on click
    public void selectEnemyTarget()
    {
        Debug.Log("running");
        GameObject partyData = GameObject.Find("PlayerParty");
        partyData.GetComponent<SelectUnit>().attackEnemyTarget(this.gameObject);
    }
}
