using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_Text : MonoBehaviour
{
    public TMP_Text npcText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        npcText.text = "Drink health potions to restore your health!";
    }
}
