using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Stats container for every unit in battle. Spawns damage text and heal text. Calculates next turn.
public class UnitStats : MonoBehaviour, IComparable
{
    public int currency;

    public float health;
    public float energy;
    public float attack;
    public float defense;
    public float speed;

    public float maxHealth;
    public float maxEnergy;
    public float defaultDefense;

    [SerializeField]
    private Vector2 damageTextPosition;

    [SerializeField]
    private GameObject damageTextPrefab;

    [SerializeField]
    private GameObject healTextPrefab;

    [SerializeField]
    private Vector2 actionEnergyTextPosition;

    [SerializeField]
    private GameObject actionEnergyTextPrefab;

    public List<StatusEffect> statusEffects;

    public int nextActTurn;

    private bool dead = false;

    static public UnitStats instance;

    [SerializeField]
    private AudioClip deathSfx;

    private void Awake(){
        instance = this;
    }

    void Start()
    {
        //this.health = this.maxHealth;
        //this.maxEnergy = this.energy;
        if (this.speed == 0)
        {
            this.speed = 1;
        }
    }

    void Update()
    {
        health = Mathf.Floor(health);

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (energy > maxEnergy)
        {
            energy = maxEnergy;
        }
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

    public void receiveDamage(float damage, bool endTurn)
    {
        //hit animation plays?

        GameObject HUDCanvas = GameObject.Find("HUDCanvas");
        GameObject damageText = Instantiate(this.damageTextPrefab, HUDCanvas.transform) as GameObject;
        damageText.GetComponent<TMP_Text>().text = "" + damage.ToString("-#.");
        damageText.transform.localPosition = this.damageTextPosition;
        damageText.transform.localScale = new Vector2(2.0f, 2.0f);

        if(this.health - damage <= 0.0f)
        {
            this.health = 0.0f;
            this.dead = true;
            this.gameObject.tag = "DeadUnit";
            //destroy enemy and return loot
            //GetComponent<LootBag>().InstantiateLoot(transform.position); //This is commented out until finished
            Destroy(this.gameObject);
            GameObject turnSystem = GameObject.Find("TurnSystem");
            turnSystem.GetComponent<TurnSystem>().nextTurn();
            GetComponent<AudioSource>().PlayOneShot(deathSfx);
        }
        else
        {
            this.health -= damage;
        }

        if (endTurn)
        {
            StartCoroutine(wait());
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

        if(this.health >= this.maxHealth)
        {
            this.health = this.maxHealth;
        }
    }

    public void increasedDefense(float defenseAmount, bool endTurn)
    {
        this.defense = this.defense * defenseAmount;

        if (endTurn)
        {
            StartCoroutine(wait());
        }
    }

    public void returnDefense()
    {
        this.defense = this.defaultDefense;
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
        dialogue.GetComponent<TMP_Text>().text = "You block and replenish some energy.";
    }

    public void ProcessStatusEffects()
    {
        if (statusEffects != null)
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
    //increase health with the potion
    public void increaseHealth(int healthBoost)
    {
        this.health += healthBoost;
    }

    public void increaseMaxHealth(int healthBoost)
    {
        this.maxHealth += healthBoost;
    }

    //increase defense with the potion
    public void increaseDefense(int defenseBoost)
    {
        this.defense += defenseBoost;
    }

    //increase attack with the sword 
    public void increaseAttack(int attackBoost){
        this.attack += attackBoost;
    }

    //increase energy
    public void increaseEnergy(int energyBoost){
        this.energy += energyBoost;
    }

    public void increaseMaxEnergy(int energyBoost)
    {
        this.maxEnergy += energyBoost;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);

        GameObject turnSystem = GameObject.Find("TurnSystem");
        turnSystem.GetComponent<TurnSystem>().nextTurn();
    }

    public void receiveCurrency(int money)
    {
        currency += money;
    }

    public void cleanStats()
    {
        health = Mathf.Ceil(health);
        energy = maxEnergy;
        nextActTurn = 0;
        for(int i = 0; i < statusEffects.Count; i++)
        {
            statusEffects[i].RemoveEffect(this);
        }
    }
}
