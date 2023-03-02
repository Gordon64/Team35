using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Manages the visibility of menus as options are selected.
public class SelectUnit : MonoBehaviour
{
    private GameObject currentUnit;

<<<<<<< HEAD
    private GameObject actionsMenu, enemyUnitsMenu, attackMenu;
=======
    private GameObject actionsMenu, enemyUnitsMenu, attacksMenu;
>>>>>>> parent of 4840068 (Merge branch 'main' of https://github.com/Gordon64/Team35)

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
        this.attackMenu.SetActive(false);
        this.actionsMenu.SetActive(false);
        this.enemyUnitsMenu.SetActive(false);
        this.attacksMenu.SetActive(false);

        this.currentUnit.GetComponent<PlayerUnitAction>().act(target);
    }
}
