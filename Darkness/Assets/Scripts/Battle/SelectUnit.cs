using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Manages the visibility of menus as options are selected.
public class SelectUnit : MonoBehaviour
{
    private GameObject currentUnit;

    private GameObject actionsMenu, enemyUnitsMenu, attacksMenu, blockMenu;

    private UnitStats currentUnitStats;
    private PlayerUnitAction currentPlayerUnitAction;

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "BattleScene")
        {
            this.actionsMenu = GameObject.Find("ActionsMenu");
            this.enemyUnitsMenu = GameObject.Find("EnemyUnitsMenu");
            this.attacksMenu = GameObject.Find("AttackMenu");
            this.blockMenu = GameObject.Find("BlockMenu");
        }
    }

    public void selectCurrentUnit(GameObject unit)
    {
        this.currentUnit = unit;
        this.actionsMenu.SetActive(true);
        this.attacksMenu.SetActive(false);
        this.blockMenu.SetActive(false);
        this.currentUnit.GetComponent<PlayerUnitAction>().updateHUD();
    }

    public void selectAttackType()
    {
        this.actionsMenu.SetActive(false);
        this.attacksMenu.SetActive(true);
        this.blockMenu.SetActive(false);
        this.enemyUnitsMenu.SetActive(false);
    }

    public void selectAttack(GameObject attack)
    {
        currentUnitStats = this.currentUnit.GetComponent<UnitStats>();
        currentPlayerUnitAction = this.currentUnit.GetComponent<PlayerUnitAction>();

        currentPlayerUnitAction.selectAttack(attack); //Selects an attack prefab

        float attackCost = currentPlayerUnitAction.currentAttack.GetComponent<AttackTarget>().energyCost; //Gets the energy cost of the attack

        //Uses the attack if enough energy can be consumed, otherwise a block attack will be used
        if (currentUnitStats.enoughActionEnergy(attackCost))
        {
            currentUnitStats.useActionEnergy(attackCost);
            this.actionsMenu.SetActive(false);
            this.attacksMenu.SetActive(false);
            this.enemyUnitsMenu.SetActive(true);
        }
        else
        {
            selectBlock();
        }
    }

    public void defaultAttack()
    {
        this.currentUnit.GetComponent<PlayerUnitAction>().basicAttack();

        this.actionsMenu.SetActive(false);
        this.attacksMenu.SetActive(false);
        this.blockMenu.SetActive(false);
        this.enemyUnitsMenu.SetActive(true);
    }

    public void attackEnemyTarget(GameObject target)
    {
        this.actionsMenu.SetActive(false);
        this.enemyUnitsMenu.SetActive(false);
        this.attacksMenu.SetActive(false);
        this.blockMenu.SetActive(false);

        this.currentUnit.GetComponent<PlayerUnitAction>().act(target);
    }

    public void selectBlock()
    {
        currentUnitStats = this.currentUnit.GetComponent<UnitStats>();

        currentUnitStats.replenishActionEnergy(3);

        this.currentUnit.GetComponent<PlayerUnitAction>().blockAttack();

        this.actionsMenu.SetActive(false);
        this.attacksMenu.SetActive(false);
        this.enemyUnitsMenu.SetActive(true);
    }

}
