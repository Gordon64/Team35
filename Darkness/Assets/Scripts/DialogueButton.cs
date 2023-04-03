
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButton : MonoBehaviour
{
    public GameObject T1, T2, T3, T4;

    public void MoveDialogue()
    {
        if (T1.activeSelf == true)
        {
            T1.SetActive(false);
            T2.SetActive(true);
        }
        else if (T2.activeSelf == true)
        {
            T2.SetActive(false);
            T3.SetActive(true);
        }
        else if (T3.activeSelf == true)
        {
            T3.SetActive(false);
            T4.SetActive(true);
        }
    }
}