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
        if (scene.name == "BattleScene")
        {
            this.actionsMenu = GameObject.Find("ActionsMenu");
            this.enemyUnitsMenu = GameObject.Find("EnemyUnitsMenu");
            this.attacksMenu = GameObject.Find("AttackMenu");
        }
    }

    public void selectCurrentUnit(GameObject unit)
    {
        this.currentUnit = unit;
        this.actionsMenu.SetActive(true);
        this.attacksMenu.SetActive(false);
        this.currentUnit.GetComponent<PlayerUnitAction>().updateHUD();
        this.currentUnit.GetComponent<PlayerUnitBlock>().updateHUD();
    }

    public void selectAttackType()
    {
        this.actionsMenu.SetActive(false);
        this.attacksMenu.SetActive(true);
        this.enemyUnitsMenu.SetActive(false);
    }

    public void selectAttack(GameObject attack)
    {
        this.currentUnit.GetComponent<PlayerUnitAction>().selectAttack(attack);

        this.actionsMenu.SetActive(false);
        this.attacksMenu.SetActive(false);
        this.enemyUnitsMenu.SetActive(true);
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
    
    //blocking code
    public void selectBlockType()
    {
        this.actionsMenu.SetActive(false);
        this.attacksMenu.SetActive(false);
        this.blockMenu.SetActive(true);
        this.enemyUnitsMenu.SetActive(false);
    }

    public void selectBlock(GameObject block)
    {
        this.currentUnit.GetComponent<PlayerUnitBlock>().selectBlock(block);

        this.actionsMenu.SetActive(false);
        this.attacksMenu.SetActive(false);
        this.blockMenu.SetActive(false);
        this.enemyUnitsMenu.SetActive(true);
    }

    public void defaultBlock()
    {
        this.currentUnit.GetComponent<PlayerUnitBlock>().basicBlock();

        this.actionsMenu.SetActive(false);
        this.attacksMenu.SetActive(false);
        this.blockMenu.SetActive(false);
        this.enemyUnitsMenu.SetActive(true);
    }
}
