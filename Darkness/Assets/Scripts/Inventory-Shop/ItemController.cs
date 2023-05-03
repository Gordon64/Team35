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
            //Health potion cases
            case InventoryItem.ItemType.Basic_Potion:
                Bandit.Instance.increaseHealth(anItem.ourValue);
                UnitStats.instance.increaseHealth(anItem.ourValue);
                break;
            //Sword cases
            case InventoryItem.ItemType.Basic_Sword:
                Bandit.Instance.increaseAttack(anItem.ourValue);
                UnitStats.instance.increaseAttack(anItem.ourValue);
                break;
            //Defense Potion cases
            case InventoryItem.ItemType.Defense_Potion:
                Bandit.Instance.increaseDefense(anItem.ourValue);
                UnitStats.instance.increaseDefense(anItem.ourValue);
                break;
            //Energy potion cases
            case InventoryItem.ItemType.Energy_Potion:
                Bandit.Instance.increaseEnergy(anItem.ourValue);
                UnitStats.instance.increaseEnergy(anItem.ourValue);
                break;
        }
        deleteItem();
    }
}
