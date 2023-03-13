using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy_Button : MonoBehaviour
{
    public GameObject YesNoPanel;
    // Start is called before the first frame update
    void Start()
    {
        YesNoPanel.SetActive(false);
    }

    public void BuyThisItem(){
        YesNoPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
