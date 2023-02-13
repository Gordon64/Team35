using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalEscapeKey : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   //checks for escape key stroke
        {
            this.gameObject.SetActive(false);
        }
    }
}