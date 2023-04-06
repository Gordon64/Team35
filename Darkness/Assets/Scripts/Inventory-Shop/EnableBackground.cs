using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnableBackground : MonoBehaviour
{
    public GameObject Background;
    private Shop_Manager shopManager;
    public GameObject thisPrefab;
    public GameObject SelectedImagePanel;
    public GameObject Description;
    public Image[] ItemSprite;
    public TMP_Text[] Text;

    void Start(){
        GameObject shopObject = GameObject.FindGameObjectWithTag("Shop");
        if(shopObject != null){
            shopManager = shopObject.GetComponent<Shop_Manager>();
        }

        if (shopObject == null){
            UnityEngine.Debug.Log("can't find GameObject");
        }
        SelectedImagePanel = GameObject.FindGameObjectWithTag("SelectedItem");
        Description = GameObject.FindGameObjectWithTag("Description");
        ItemSprite = SelectedImagePanel.GetComponentsInChildren<Image>();
        Text = Description.GetComponentsInChildren<TMP_Text>();
    }

    public void Enable()
    {
        for(int i = 0; i < shopManager.ItemPrefabs.Length; i++){
            if(shopManager.ItemPrefabs[i] == null){
                UnityEngine.Debug.Log("couldn't find prefabs list");
            }
            else{
                if(thisPrefab == shopManager.ItemPrefabs[i]){
                    UnityEngine.Debug.Log("prefab found");
                    DisplayItemInfo(shopManager.ShopItems[i]);
                    shopManager.setSelectedItem(shopManager.ShopItems[i]);
                }
                else{
                    UnityEngine.Debug.Log("no prefab found");
                    shopManager.ItemPrefabs[i].transform.Find("Background").gameObject.SetActive(false);
                }
            }
        }
        Background.SetActive(true);
    }

    void DisplayItemInfo(InventoryItem Item){
        foreach(Image imageComponent in ItemSprite){
            if(imageComponent.name == "ImageBoarder"){
                imageComponent.sprite = Item.itemIcon;
            }
        }
        foreach(TMP_Text selectText in Text){
            if(selectText.name == "DesTitle"){
                selectText.text = Item.itemName;  
            }

            if(selectText.name == "DesText"){
                selectText.text = Item.itemDescription;
                UnityEngine.Debug.Log(Item.itemDescription);
            }
            if(selectText.name == "Cost"){
                selectText.text = "   Cost: " + Item.shopCost;
            }
        }
    }

    void Update()
    {

    }
}
