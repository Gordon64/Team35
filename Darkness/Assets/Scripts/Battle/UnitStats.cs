using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Stats container for every unit in battle. Spawns damage text and heal text. Calculates next turn.
public class UnitStats : MonoBehaviour, IComparable
{
    public float health;
    public float energy;
    public float attack;
    public float defense;
    public float speed;

    public float maxHealth;
    public float maxEnergy;

    [SerializeField]
    private Vector2 damageTextPosition;

    [SerializeField]
    private GameObject damageTextPrefab;

    [SerializeField]
    private Vector2 actionEnergyTextPosition;

    [SerializeField]
    private GameObject actionEnergyTextPrefab;

    [SerializeField]
    private GameObject healTextPrefab;

    public List<StatusEffect> statusEffects;

    public int nextActTurn;

    private bool dead = false;

    void Start()
    {
        this.maxHealth = this.health;
        this.maxEnergy = this.energy;
    }

    public void calculateNextActTurn(int currentTurn)
    {
        this.nextActTurn = currentTurn + (int)Math.Ceiling(100.0f / this.speed);
    }

    public int CompareTo(object otherStats)
    {
        return nextActTurn.CompareTo(((UnitStats)otherStats).nextActTurn);
    }

    public bool isDead()
    {
        return this.dead;
    }

    public void receiveDamage(float damage)
    {
        this.health -= damage;
        //hit animation plays

        GameObject HUDCanvas = GameObject.Find("HUDCanvas");
        GameObject damageText = Instantiate(this.damageTextPrefab, HUDCanvas.transform) as GameObject;
        damageText.GetComponent<TMP_Text>().text = "" + damage.ToString("-#.");
        damageText.transform.localPosition = this.damageTextPosition;
        damageText.transform.localScale = new Vector2(2.0f, 2.0f);

        Debug.Log(damage);

        if(this.health <= 0)
        {
            this.dead = true;
            this.gameObject.tag = "DeadUnit";
            Destroy(this.gameObject);
        }
    }

    public bool enoughActionEnergy(float energySpent)
    {
        float totalActionEnergy = this.energy - energySpent;
        if (totalActionEnergy < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void useActionEnergy(float energySpent)
    {
        this.energy -= energySpent;
        
        GameObject HUDCanvas = GameObject.Find("HUDCanvas");
        GameObject energySpentText = Instantiate(this.actionEnergyTextPrefab, HUDCanvas.transform) as GameObject;
        energySpentText.GetComponent<TMP_Text>().text = "" + energySpent.ToString("-#.");
        energySpentText.transform.localPosition = this.actionEnergyTextPosition;
        energySpentText.transform.localScale = new Vector2(2.0f, 2.0f);
    }

    public void replenishActionEnergy(float energyRefill)
    {
        this.energy += energyRefill;
        if (this.energy > maxEnergy)
        {
            this.energy = maxEnergy;
        }

        GameObject HUDCanvas = GameObject.Find("HUDCanvas");
        GameObject energySpentText = Instantiate(this.actionEnergyTextPrefab, HUDCanvas.transform) as GameObject;
        energySpentText.GetComponent<TMP_Text>().text = "" + energyRefill.ToString("+#.");
        energySpentText.transform.localPosition = this.actionEnergyTextPosition;
        energySpentText.transform.localScale = new Vector2(2.0f, 2.0f);

        GameObject dialogue = GameObject.Find("DialogueBox") as GameObject;
        dialogue.GetComponent<TMP_Text>().text = "You wait and replenish some energy.";
    }

    public void receiveHeal(float heal)
    {
        this.health += heal;

        GameObject HUDCanvas = GameObject.Find("HUDCanvas");
        GameObject damageText = Instantiate(this.healTextPrefab, HUDCanvas.transform) as GameObject;
        damageText.GetComponent<TMP_Text>().text = "" + heal.ToString("+#.");
        damageText.transform.localPosition = this.damageTextPosition;
        damageText.transform.localScale = new Vector2(2.0f, 2.0f);
        Debug.Log(heal);

        if(this.health >= this.maxHealth)
        {
            this.health = this.maxHealth;
        }
    }

    public void ProcessStatusEffects()
    {
        for (int i = statusEffects.Count - 1; i >= 0; i--)
        {
            StatusEffect statusEffect = statusEffects[i];
            statusEffect.DecreaseDuration();

            if(statusEffect.duration <= 0)
            {
                statusEffects.RemoveAt(i);
            }
            else
            {
                statusEffect.OnTurnStart(this);
            }
        }
    }
}
