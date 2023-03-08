using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public InventoryItem anItem;
    public Button RemoveButton;
    // public Bandit bandit;


    // void Start()
    // {
    //     bandit = FindObjectOfType<Bandit>();
    // }


    public void deleteItem()
    {
        InventoryManager.Instance.Remove(anItem);
        Destroy(gameObject);
    }

    public void addItem(InventoryItem newItem)
    {
        anItem = newItem;
    }

    // public void UseItem()
    // {
    //     switch(anItem.itemType)
    //     {
    //         case InventoryItem.ItemType.Basic_Potion:
    //             bandit.health += 3;
    //             break;
    //         //no case for attack yet
    //         case InventoryItem.ItemType.Basic_Sword:
    //             // bandit.attack += 5;
    //             break;
    //     }
    //     deleteItem();
    // }
}
