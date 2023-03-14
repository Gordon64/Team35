using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yes_No_Script : MonoBehaviour
{
    public GameObject YesNoPanel;
    private Shop_Manager shopManager;
    private InventoryItem Item;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Shop");
        if(playerObject != null){
            shopManager = playerObject.GetComponent<Shop_Manager>();
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
