using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitAction : MonoBehaviour
{
    [SerializeField]
    private GameObject physicalAttack;

    [SerializeField]
    public List<GameObject> attacks;

    private GameObject currentAttack;

    //Manages player action during player's turn.
    void Awake()
    {
        this.physicalAttack = Instantiate(this.physicalAttack, this.transform);
        this.physicalAttack.GetComponent<AttackTarget>().owner = this.gameObject;

        this.currentAttack = this.physicalAttack;

        for (int i = 0; i < attacks.Count; i++)
        {
            attacks[i] = Instantiate(attacks[i], this.transform);
            attacks[i].GetComponent<AttackTarget>().owner = this.gameObject;
        }
    }

    public void act (GameObject target)
    {
        this.currentAttack.GetComponent<AttackTarget>().hit(target);
    }

    public void selectAttack(GameObject newAttack)
    {
        this.currentAttack = newAttack;
    }

    public void basicAttack()
    {
        this.currentAttack = physicalAttack;
    }

    public void updateHUD()
    {
        GameObject playerUnitHealthBar = GameObject.Find("PlayerHealthBar") as GameObject;
        playerUnitHealthBar.GetComponent<ShowUnitHealth>().changeUnit(this.gameObject);
        GameObject playerActionEnergyBar = GameObject.Find("PlayerActionEnergyBar") as GameObject;
        playerActionEnergyBar.GetComponent<ShowActionEnergy>().changeUnit(this.gameObject);
    }
}
