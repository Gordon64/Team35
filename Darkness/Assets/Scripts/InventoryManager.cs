using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager im;
    public List<InventoryItem> ourItems = new List<InventoryItem>();

    public Transform ItemContent;
    public GameObject TheItem;

    public void Awake()
    {
        im = this;
    }

    public void Add(InventoryItem anItem)
    {
        ourItems.Add(anItem);
    }

    public void Delete(InventoryItem anItem)
    {
        ourItems.Remove(anItem);
    }

    public void ListOfItems()
    {
        foreach (var anItem in ourItems)
        {
            GameObject ob = Instantiate(TheItem, ItemContent);
            var ItemText = ob.transform.Find("ItemText").GetComponent<Text>();
            var ItemImage = ob.transform.Find("ItemImage").GetComponent<Image>();

            ItemText.text = anItem.itemName;
            ItemImage.sprite  = anItem.itemIcon;
        }
    }
}
