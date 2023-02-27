using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitAction : MonoBehaviour
{
    [SerializeField]
    private GameObject physicalAttack;

    private GameObject currentAttack;

    //Manages player action during player's turn.
    void Awake()
    {
        this.physicalAttack = Instantiate(this.physicalAttack, this.transform);

        this.physicalAttack.GetComponent<AttackTarget>().owner = this.gameObject;

        this.currentAttack = this.physicalAttack;
    }

    public void act (GameObject target)
    {
        this.currentAttack.GetComponent<AttackTarget>().hit(target);
    }

    public void selectAttack()
    {
        this.currentAttack = this.physicalAttack;
    }

    public void updateHUD()
    {
        GameObject playerUnitHealthBar = GameObject.Find("PlayerHealthBar") as GameObject;
        playerUnitHealthBar.GetComponent<ShowUnitHealth>().changeUnit(this.gameObject);
        GameObject playerActionEnergyBar = GameObject.Find("PlayerActionEnergyBar") as GameObject;
        playerActionEnergyBar.GetComponent<ShowActionEnergy>().changeUnit(this.gameObject);
    }
}
