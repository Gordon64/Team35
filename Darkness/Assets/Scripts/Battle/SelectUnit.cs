using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Manages the visibility of menus as options are selected.
public class SelectUnit : MonoBehaviour
{
    private GameObject currentUnit;

    private GameObject actionsMenu, enemyUnitsMenu, attackMenu;

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "BattleScene")
        {
            this.attackMenu = GameObject.Find("AttackMenu");
            this.actionsMenu = GameObject.Find("ActionsMenu");
            this.enemyUnitsMenu = GameObject.Find("EnemyUnitsMenu");
        }
    }

    public void selectCurrentUnit(GameObject unit)
    {
        this.currentUnit = unit;
        this.actionsMenu.SetActive(true);
        this.currentUnit.GetComponent<PlayerUnitAction>().updateHUD();
    }

    public void selectAttack()
    {
        this.currentUnit.GetComponent<PlayerUnitAction>().selectAttack();
        this.attackMenu.SetActive(false);
        this.actionsMenu.SetActive(false);
        this.enemyUnitsMenu.SetActive(true);
    }

    public void attackEnemyTarget(GameObject target)
    {
        this.attackMenu.SetActive(false);
        this.actionsMenu.SetActive(false);
        this.enemyUnitsMenu.SetActive(false);

        this.currentUnit.GetComponent<PlayerUnitAction>().act(target);
    }
}
