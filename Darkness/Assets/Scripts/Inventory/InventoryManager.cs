using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<InventoryItem> ourItems = new List<InventoryItem>();

    public Transform ItemContent;
    public GameObject TheItem;

    public Toggle RemoveItems;

    public void Awake()
    {
        Instance = this;
    }

    public void Add(InventoryItem anItem)
    {
        ourItems.Add(anItem);
    }

    public void Remove(InventoryItem anItem)
    {
        ourItems.Remove(anItem);
    }

    public void ListOfItems()
    {
        //prevents duplicates
        foreach (Transform anItem in ItemContent)
        {
            Destroy(anItem.gameObject);
        }

        //prints item name & image to inventory
        foreach (var anItem in ourItems)
        {
            GameObject ob = Instantiate(TheItem, ItemContent);
            var ItemText = ob.transform.Find("ItemText").GetComponent<TextMeshProUGUI>();
            var ItemImage = ob.transform.Find("ItemImage").GetComponent<Image>();

            ItemText.text = anItem.itemName;
            ItemImage.sprite  = anItem.itemIcon;
        }
    }

    //allows to remove items from inventory
    public void allowRemoveItems()
    {
        if (RemoveItems.isOn)
        {
            foreach (Transform anItem in ItemContent)
            {
                anItem.Find("RemoveButton").gameObject.SetActive(true);
            }
        } else 
        {
            foreach (Transform anItem in ItemContent)
            {
                anItem.Find("RemoveButton").gameObject.SetActive(false);
            }
        }

    }
}
