using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackTarget : MonoBehaviour
{
    public GameObject owner;

    [SerializeField]
    private float minAttackMultiplier;
    [SerializeField]
    private float maxAttackMultiplier;

    [SerializeField]
    private float minDefenseMultiplier;
    [SerializeField]
    private float maxDefenseMultiplier;

    [SerializeField]
    private float minLifestealMultiplier;
    [SerializeField]
    private float maxLifestealMultiplier;

    [SerializeField]
    private string prehitDialogue;
    [SerializeField]
    private string posthitDialogue;

    public void hit (GameObject target)
    {
        UnitStats ownerStats = this.owner.GetComponent<UnitStats>();
        UnitStats targetStats = target.GetComponent<UnitStats>();

        //damage increase based on owner's stats
        //could create critical hits
        float attackMultiplier = (Random.value * (this.maxAttackMultiplier - this.minAttackMultiplier)) + this.minAttackMultiplier;
        float damage = attackMultiplier * ownerStats.attack;

        //damage reduction based on target stats
        float defenseMultiplier = (Random.value * (this.maxDefenseMultiplier - this.minDefenseMultiplier)) + this.minDefenseMultiplier;
        damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));

        //lifesteal multiplier
        float lifestealMultiplier = (Random.value * (this.minLifestealMultiplier - this.maxLifestealMultiplier)) + this.minLifestealMultiplier;
        float heal = lifestealMultiplier * damage;

        GameObject dialogue = GameObject.Find("DialogueBox") as GameObject;
        dialogue.GetComponent<TMP_Text>().text = posthitDialogue;

        targetStats.receiveDamage(damage);

        if (heal > 0)
        {
            ownerStats.receiveHeal(heal);
        }
    }
}
