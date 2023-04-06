using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yes_No_Script : MonoBehaviour
{
    public GameObject YesNoPanel;
    private Shop_Manager shopManager;
    private InventoryItem Item;
    public InventoryManager Inventory;
    // Start is called before the first frame update
    void Start()
    {
        GameObject inventoryObject = GameObject.FindGameObjectWithTag("Inventory");
        GameObject shopObject = GameObject.FindGameObjectWithTag("Shop");

        if(inventoryObject != null){
            Inventory = inventoryObject.GetComponent<InventoryManager>();
        }
        else{
            UnityEngine.Debug.Log("can't find inventory");
        }

        if(shopObject != null){
            shopManager = shopObject.GetComponent<Shop_Manager>();
        }
        else{
            UnityEngine.Debug.Log("can't find GameObject");
        }
        YesNoPanel.SetActive(false);
    }

    public void Update(){
        Item = shopManager.getSelectedItem();
    }

    public void YesButton(){
        if(shopManager.TutPlayerWallet >= Item.shopCost){
            YesNoPanel.SetActive(false);
            Inventory.Add(Item);
            shopManager.TutPlayerWallet = shopManager.TutPlayerWallet - Item.shopCost;      
            UnityEngine.Debug.Log(shopManager.TutPlayerWallet);
        }
        else{
            UnityEngine.Debug.Log("Not enough money!");
        }
    }

    public void NoButton(){
        YesNoPanel.SetActive(false);
    }

}
