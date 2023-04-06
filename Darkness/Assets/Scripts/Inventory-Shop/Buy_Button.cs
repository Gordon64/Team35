using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy_Button : MonoBehaviour
{
    public GameObject YesNoPanel;
    private Shop_Manager shopManager;
    public GameObject shop;

    public InventoryItem selectedItem;
    // Start is called before the first frame update
    void Start()
    {
        shopManager = shop.GetComponent<Shop_Manager>();
        YesNoPanel.SetActive(false);
    }

    public void BuyThisItem(){
        if(selectedItem != null)
            YesNoPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        selectedItem = shopManager.getSelectedItem();
    }
}
