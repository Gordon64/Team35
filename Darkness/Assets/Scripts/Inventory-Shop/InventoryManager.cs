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

    public ItemController[] invItems;

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
            var removeButton = ob.transform.Find("RemoveButton").GetComponent<Button>();

            ItemText.text = anItem.itemName;
            ItemImage.sprite  = anItem.itemIcon;

            if(RemoveItems.isOn)
            {
                removeButton.gameObject.SetActive(true);
            }
          
                
        }

        SetInvItems();
    }

    public void removeDuplicates(){
        //prevents duplicates
        foreach (Transform anItem in ItemContent)
        {
            Destroy(anItem.gameObject);
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
        } else {
            foreach (Transform anItem in ItemContent)
            {
                anItem.Find("RemoveButton").gameObject.SetActive(false);
            }
        }

    }

    //set the items in the inventory
    public void SetInvItems()
    {
        invItems = ItemContent.GetComponentsInChildren<ItemController>();

        for (int n = 0; n < ourItems.Count; n++)
        {
            invItems[n].addItem(ourItems[n]);
        }
    }
}
