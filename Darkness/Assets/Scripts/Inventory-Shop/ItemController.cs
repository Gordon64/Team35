using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public InventoryItem anItem;
    public Button RemoveButton;
    public UnitStats player;


    // void Start()
    // {
    //     bandit = FindObjectOfType<Bandit>();
    // }

    void Start()
    {
        player = FindObjectOfType<UnitStats>();
    }

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
                if (player.health <= (player.maxHealth-2)){
                    Bandit.Instance.increaseHealth(anItem.ourValue);
                    player.increaseHealth(anItem.ourValue);
                } else {
                    Bandit.Instance.health = player.maxHealth;
                    player.health = player.maxHealth;
                }
                break;
            case InventoryItem.ItemType.Better_Potion:
                if (player.health <= (player.maxHealth-4)){
                    Bandit.Instance.increaseHealth(anItem.ourValue);
                    player.increaseHealth(anItem.ourValue);
                } else {
                    Bandit.Instance.health = player.maxHealth;
                    player.health = player.maxHealth;
                }
                break;
            case InventoryItem.ItemType.Best_Potion:
                if (player.health <= (player.maxHealth-6)){
                    Bandit.Instance.increaseHealth(anItem.ourValue);
                    player.increaseHealth(anItem.ourValue);
                } else {
                    Bandit.Instance.health = player.maxHealth;
                    player.health = player.maxHealth;
                }
                break;
            //Sword cases
            case InventoryItem.ItemType.Basic_Sword:
                Bandit.Instance.increaseAttack(anItem.ourValue);
                player.increaseAttack(anItem.ourValue);
                break;
            //Defense Potion cases
            case InventoryItem.ItemType.Defense_Potion:
                //if (player.defense <= )
                Bandit.Instance.increaseDefense(anItem.ourValue);
                player.increaseDefense(anItem.ourValue);
                break;
            case InventoryItem.ItemType.Better_Defense_Potion:
                Bandit.Instance.increaseDefense(anItem.ourValue);
                player.increaseDefense(anItem.ourValue);
                break;
            case InventoryItem.ItemType.Best_Defense_Potion:
                Bandit.Instance.increaseDefense(anItem.ourValue);
                player.increaseDefense(anItem.ourValue);
                break;

            //Energy potion cases
            case InventoryItem.ItemType.Energy_Potion:
                if (player.energy <= (player.maxEnergy-2)){
                    Bandit.Instance.increaseEnergy(anItem.ourValue);
                    player.increaseEnergy(anItem.ourValue);
                } else {
                    player.energy = player.maxEnergy;
                }
                break;
            case InventoryItem.ItemType.Better_Energy_Potion:
                if (player.energy <= (player.maxEnergy-4)){
                    Bandit.Instance.increaseEnergy(anItem.ourValue);
                    player.increaseEnergy(anItem.ourValue);
                } else {
                    player.energy = player.maxEnergy;
                }
                break;
            case InventoryItem.ItemType.Best_Energy_Potion:
                if (player.energy <= (player.maxEnergy-6)){
                    Bandit.Instance.increaseEnergy(anItem.ourValue);
                    player.increaseEnergy(anItem.ourValue);
                } else {
                    player.energy = player.maxEnergy;
                }
                break;
        }
        deleteItem();
    }
}
