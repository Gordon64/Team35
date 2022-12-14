using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AddButtonCallback : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(() => addCallback());
    }

    private void addCallback()
    {
        GameObject playerParty = GameObject.Find("PlayerParty");
        playerParty.GetComponent<SelectUnit>().selectAttack();
    }
}
