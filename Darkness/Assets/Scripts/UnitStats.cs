using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UnitStats : MonoBehaviour, IComparable
{
    public float health;
    public float attack;
    public float defense;
    public float speed;

    [SerializeField]
    private Vector2 damageTextPosition;

    [SerializeField]
    private GameObject damageTextPrefab;

    public int nextActTurn;

    private bool dead = false;

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
        damageText.GetComponent<TMP_Text>().text = "" + damage;
        damageText.transform.localPosition = this.damageTextPosition;
        damageText.transform.localScale = new Vector2(1.0f, 1.0f);
        Debug.Log(damage);

        if(this.health <= 0)
        {
            this.dead = true;
            this.gameObject.tag = "DeadUnit";
            Destroy(this.gameObject);
        }
    }
}
