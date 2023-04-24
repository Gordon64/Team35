using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GotHurtEffect : MonoBehaviour
{
    private GameObject playerUnit;
    private UnitStats playerStats;
    private float health;

    [SerializeField]
    public GameObject gotHurtScreen;


    void Start()
    {
        //reading from PlayerParty's PlayerUnit's UnitStats
        playerUnit = GameObject.FindGameObjectWithTag("PlayerUnit");
        playerStats = playerUnit.GetComponent<UnitStats>();
        health = playerStats.health;
    }

    void Update()
    {   
        //check for player damage
        if (health > playerStats.health)
        {
            GotHurt();
            health = playerStats.health;
        }

        //update hurt screen splash, reducing opacity every update
        if (gotHurtScreen != null)
        {
            if (gotHurtScreen.GetComponent<Image>().color.a > 0)
            {
                var color = gotHurtScreen.GetComponent<Image>().color;
                color.a -= 0.0005f;

                gotHurtScreen.GetComponent<Image>().color = color;
            }
        }
    }

    //sets the opacity of the hurt screen splash if player is damaged
    private void GotHurt()
    {
        var color = gotHurtScreen.GetComponent<Image>().color;
        color.a = 0.3f;

        gotHurtScreen.GetComponent<Image>().color = color;
    }
}

