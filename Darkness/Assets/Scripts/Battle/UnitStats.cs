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
    public float attack;
    public float defense;
    public float speed;

    private float maxHealth;

    [SerializeField]
    private Vector2 damageTextPosition;

    [SerializeField]
    private GameObject damageTextPrefab;

    [SerializeField]
    private GameObject healTextPrefab;

    public List<StatusEffect> statusEffects;

    public int nextActTurn;

    private bool dead = false;

    void Start()
    {
        this.maxHealth = this.health;
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
