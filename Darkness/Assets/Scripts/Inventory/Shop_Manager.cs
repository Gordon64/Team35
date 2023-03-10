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

    public Transform ItemContent;
    public GameObject Item;

    public void Start()
    {
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
}
