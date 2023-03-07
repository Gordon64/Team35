using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public InventoryItem inventoryItem;
    public Bandit bandit;


    void Start()
    {
        bandit = FindObjectOfType<Bandit>();
    }


    public void deleteItem(){
        InventoryManager.Instance.Remove(inventoryItem);
        Destroy(this.gameObject);
    }

    public void UseItem(){
        switch(inventoryItem.itemType){
            case InventoryItem.ItemType.Basic_Potion:
                bandit.health += 3;
                break;
            //no case for attack yet
            case InventoryItem.ItemType.Basic_Sword:
                // bandit.attack += 5;
                break;
        }
        deleteItem();
    }
}
