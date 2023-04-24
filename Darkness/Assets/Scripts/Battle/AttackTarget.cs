using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackTarget : MonoBehaviour
{
    public GameObject owner;

    [SerializeField]
    public float energyCost;

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
    private string hitDialogue;

    private string dialogueOutput;

    [SerializeField]
    private StatusEffect statusEffect;

    [SerializeField]
    private StatusEffect buffEffect;

    [SerializeField]
    private GameObject animationEffect;

    //calculates damage and heal based on target and attack owner's stats. Changes dialogue box according to attack.
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

        //dialogue setting
        GameObject dialogue = GameObject.Find("DialogueBox") as GameObject;
        dialogueOutput = hitDialogue.Replace("(enemy)", targetStats.name);
        dialogue.GetComponent<TMP_Text>().text = dialogueOutput;

        targetStats.receiveDamage(damage, true);

        if (heal > 0)
        {
            ownerStats.receiveHeal(heal);
        }

        if (statusEffect != null)
        {
            statusEffect.ApplyEffect(targetStats);
        }

        if (buffEffect != null)
        {
            buffEffect.ApplyEffect(ownerStats);
        }

        if(animationEffect != null)
        {
            Instantiate(animationEffect, target.transform.position, Quaternion.identity);
        }
    }
}
