using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UnityEngine;

public class NPC_Trigger : MonoBehaviour
{
    public GameObject TextPanel, firstText, d1, d2;
    public Dialogue tutorial;
    // Start is called before the first frame update
    void Start()
    {
        TextPanel.SetActive(false);
        firstText.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (TextPanel.activeSelf == false)
        {
            d1.SetActive(false);
            d2.SetActive(false);
            TextPanel.SetActive(true);
            firstText.SetActive(true);
        }
    }

    public void StartDialogue()
    {
        FindObjectOfType<DialogueScript>().ActivateTutorial(tutorial);
    }
    // Update is called once per frame
    void Update()
    {

    }
}