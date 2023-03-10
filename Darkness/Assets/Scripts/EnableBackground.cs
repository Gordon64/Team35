using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class EnableBackground : MonoBehaviour
{
    public GameObject Background;
    private Shop_Manager shopManager;
    public GameObject thisPrefab;
    public GameObject SelectedImagePanel;
    public Image[] ItemSprite;

    void Start(){
        GameObject playerObject = GameObject.FindGameObjectWithTag("Shop");
        if(playerObject != null){
            shopManager = playerObject.GetComponent<Shop_Manager>();
        }
        else{
            UnityEngine.Debug.Log("can't find GameObject");
        }
        SelectedImagePanel = GameObject.FindGameObjectWithTag("SelectedItem");
        ItemSprite = SelectedImagePanel.GetComponentsInChildren<Image>();
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
            //add name and description that need to be passed to text boxes
        }
    }

    void Update()
    {

    }
}
