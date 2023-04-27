using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public InventoryItem anItem;
    public Button RemoveButton;
    //public Bandit bandit;


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

    public void UseItem()
    {
        switch(anItem.itemType)
        {
            case InventoryItem.ItemType.Basic_Potion:
                Bandit.Instance.increaseHealth(anItem.ourValue);
                UnitStats.instance.increaseHealth(anItem.ourValue);
                break;
            //no case for attack yet
            case InventoryItem.ItemType.Basic_Sword:
                // bandit.attack += 5;
                break;
            case InventoryItem.ItemType.Defense_Potion:
                Bandit.Instance.increaseDefense(anItem.ourValue);
                UnitStats.instance.increaseDefense(anItem.ourValue);
                break;
        }
        deleteItem();
    }
}
