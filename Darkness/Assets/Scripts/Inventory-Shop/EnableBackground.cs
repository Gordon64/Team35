using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnableBackground : MonoBehaviour
{
    Shop_Manager shopManager;
    public GameObject Background;
    void awake(){
        shopManager = GameObject.FindWithTag("ShopUnit").GetComponent<Shop_Manager>();
    }
    public void start(){
        shopManager = GameObject.FindWithTag("ShopUnit").GetComponent<Shop_Manager>();
    }

    public void Enable()
    {
        foreach (var anItem in shopManager.ShopItems)
        {
            if(shopManager.Item != null){

                Background.SetActive(true);
            }
            else
            {
                Background.SetActive(false);
            }
        }
    }

    void Update()
    {
        
    }
}
