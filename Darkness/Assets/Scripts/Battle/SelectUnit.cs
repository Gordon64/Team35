using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Manages the visibility of menus as options are selected.
public class SelectUnit : MonoBehaviour
{
    private GameObject currentUnit;

    private GameObject actionsMenu, enemyUnitsMenu;

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
        UnitStats currentUnitStats = this.currentUnit.GetComponent<UnitStats>();
        if (currentUnitStats.enoughActionEnergy(5))
        {
            currentUnitStats.useActionEnergy(5);
            this.currentUnit.GetComponent<PlayerUnitAction>().selectAttack();
            this.actionsMenu.SetActive(false);
            this.enemyUnitsMenu.SetActive(true);
        }
        else
        {
            selectWait();
        }
    }
    
    public void selectWait()
    {
        UnitStats currentUnitStats = this.currentUnit.GetComponent<UnitStats>();
        currentUnitStats.replenishActionEnergy(3);
    }
    
    public void attackEnemyTarget(GameObject target)
    {
        this.actionsMenu.SetActive(false);
        this.enemyUnitsMenu.SetActive(false);

        this.currentUnit.GetComponent<PlayerUnitAction>().act(target);
    }
}
