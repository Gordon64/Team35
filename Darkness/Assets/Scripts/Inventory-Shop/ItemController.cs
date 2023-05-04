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
                if (UnitStats.instance.health <= 28){
                    Bandit.Instance.increaseHealth(anItem.ourValue);
                    UnitStats.instance.increaseHealth(anItem.ourValue);
                } else {
                    Bandit.Instance.health = 30;
                    UnitStats.instance.health = UnitStats.instance.maxHealth;
                }
                break;
            case InventoryItem.ItemType.Better_Potion:
                if (UnitStats.instance.health <= 26){
                    Bandit.Instance.increaseHealth(anItem.ourValue);
                    UnitStats.instance.increaseHealth(anItem.ourValue);
                } else {
                    Bandit.Instance.health = 30;
                    UnitStats.instance.health = UnitStats.instance.maxHealth;
                }
                break;
            case InventoryItem.ItemType.Best_Potion:
                if (UnitStats.instance.health <= 24){
                    Bandit.Instance.increaseHealth(anItem.ourValue);
                    UnitStats.instance.increaseHealth(anItem.ourValue);
                } else {
                    Bandit.Instance.health = 30;
                    UnitStats.instance.health = UnitStats.instance.maxHealth;
                }
                break;
            //Sword cases
            case InventoryItem.ItemType.Basic_Sword:
                Bandit.Instance.increaseAttack(anItem.ourValue);
                UnitStats.instance.increaseAttack(anItem.ourValue);
                break;
            //Defense Potion cases
            case InventoryItem.ItemType.Defense_Potion:
                //if (UnitStats.instance.defense <= )
                Bandit.Instance.increaseDefense(anItem.ourValue);
                UnitStats.instance.increaseDefense(anItem.ourValue);
                break;
            case InventoryItem.ItemType.Better_Defense_Potion:
                Bandit.Instance.increaseDefense(anItem.ourValue);
                UnitStats.instance.increaseDefense(anItem.ourValue);
                break;
            case InventoryItem.ItemType.Best_Defense_Potion:
                Bandit.Instance.increaseDefense(anItem.ourValue);
                UnitStats.instance.increaseDefense(anItem.ourValue);
                break;

            //Energy potion cases
            case InventoryItem.ItemType.Energy_Potion:
                if (UnitStats.instance.energy <= 8){
                    Bandit.Instance.increaseEnergy(anItem.ourValue);
                    UnitStats.instance.increaseEnergy(anItem.ourValue);
                } else {
                    Bandit.Instance.defense = 10;
                    UnitStats.instance.defense = UnitStats.instance.maxEnergy;
                }
                break;
            case InventoryItem.ItemType.Better_Energy_Potion:
                if (UnitStats.instance.energy <= 6){
                    Bandit.Instance.increaseEnergy(anItem.ourValue);
                    UnitStats.instance.increaseEnergy(anItem.ourValue);
                } else {
                    Bandit.Instance.defense = 10;
                    UnitStats.instance.defense = UnitStats.instance.maxEnergy;
                }
                break;
            case InventoryItem.ItemType.Best_Energy_Potion:
                if (UnitStats.instance.energy <= 4){
                    Bandit.Instance.increaseEnergy(anItem.ourValue);
                    UnitStats.instance.increaseEnergy(anItem.ourValue);
                } else {
                    Bandit.Instance.defense = 10;
                    UnitStats.instance.defense = UnitStats.instance.maxEnergy;
                }
                break;
        }
        deleteItem();
    }
}
