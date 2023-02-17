using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class EnableBackground : MonoBehaviour
{
    public GameObject Background;

    public void Enable()
    {
        Background.SetActive(true);
    }

    void Update()
    {

    }
}
