using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop_Manager : MonoBehaviour
{
    public static Shop_Manager instance;
    public List<InventoryItem> ShopItems = new List<InventoryItem>();
    public GameObject[] ItemPrefabs;
    public int context = 0;
    public InventoryItem SelectedItem;

    public Transform ItemContent;
    public GameObject Item;
    public int PlayerWallet;
    public TMP_Text Money;

    public void Start()
    {
        UnitStats player = FindObjectOfType<UnitStats>();
        PlayerWallet = player.currency;

        foreach (var anItem in ShopItems)
        {
            GameObject ob = Instantiate(Item, ItemContent);
            if(context >= ItemPrefabs.Length){
                System.Array.Resize(ref ItemPrefabs, context + 1);
            }
            ItemPrefabs[context] = ob;
            
            var ItemImage = ob.transform.Find("Image").GetComponent<Image>();

            context++;
            ItemImage.sprite = anItem.itemIcon;
        }
    }
    public void Update(){
       // string Number = Convert.ToString(TutPlayerWallet);
        Money.text = "Money: " + PlayerWallet;
    }

    public void setSelectedItem(InventoryItem Item){
        SelectedItem = Item;
    }

    public InventoryItem getSelectedItem(){
        return SelectedItem;
    }


}
