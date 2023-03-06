using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Manages the visibility of menus as options are selected.
public class SelectUnit : MonoBehaviour
{
    private GameObject currentUnit;

    private GameObject actionsMenu, enemyUnitsMenu, attacksMenu;

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "BattleScene")
        {
            this.actionsMenu = GameObject.Find("ActionsMenu");
            this.enemyUnitsMenu = GameObject.Find("EnemyUnitsMenu");
            this.attacksMenu = GameObject.Find("SkillsMenu");
        }
    }

    public void selectCurrentUnit(GameObject unit)
    {
        this.currentUnit = unit;
        this.actionsMenu.SetActive(true);
        this.attacksMenu.SetActive(false);
        this.currentUnit.GetComponent<PlayerUnitAction>().updateHUD();
    }

    public void selectBlock()
    {
        UnitStats currentUnitStats = this.currentUnit.GetComponent<UnitStats>();
        currentUnitStats.replenishActionEnergy(3);

        this.currentUnit.GetComponent<PlayerUnitAction>().blockAttack();

        this.actionsMenu.SetActive(false);
        this.attacksMenu.SetActive(false);
        this.enemyUnitsMenu.SetActive(true);
    }

    public void selectAttackType()
    {
        this.actionsMenu.SetActive(false);
        this.attacksMenu.SetActive(true);
        this.enemyUnitsMenu.SetActive(false);
    }

    public void selectAttack(GameObject attack)
    {
        /*
        this.currentUnit.GetComponent<PlayerUnitAction>().selectAttack(attack);

        this.actionsMenu.SetActive(false);
        this.attacksMenu.SetActive(false);
        this.enemyUnitsMenu.SetActive(true);
        */

        UnitStats currentUnitStats = this.currentUnit.GetComponent<UnitStats>();
        if (currentUnitStats.enoughActionEnergy(5))
        {
            currentUnitStats.useActionEnergy(5);
            this.currentUnit.GetComponent<PlayerUnitAction>().selectAttack(attack);
            this.actionsMenu.SetActive(false);
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
        this.enemyUnitsMenu.SetActive(true);
    }

    public void attackEnemyTarget(GameObject target)
    {
        this.actionsMenu.SetActive(false);
        this.enemyUnitsMenu.SetActive(false);
        this.attacksMenu.SetActive(false);

        this.currentUnit.GetComponent<PlayerUnitAction>().act(target);
    }
}
