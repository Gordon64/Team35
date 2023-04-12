using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{

    public GameObject droppedItem;
    public List<InventoryItem> lootList = new List<InventoryItem>();

    //gets items to be dropped
    List<InventoryItem> obtainItemsDropped(){
        int randomNumber = Random.Range(1, 101);
        List<InventoryItem> potentialDrops = new List<InventoryItem>();
        foreach(InventoryItem loot in lootList){
            if(randomNumber <= loot.probability){
                potentialDrops.Add(loot);
                return potentialDrops;
            }
        }


        //if no loot dropped
        Debug.Log("Loot was not dropped.");
        return null;
    }

    public void InstantiateLoot(Vector3 spawnLocation){
        List<InventoryItem> droppedLoot =  obtainItemsDropped();
        if (droppedLoot != null){
            foreach(InventoryItem loot in droppedLoot){
                GameObject lootGO = Instantiate(droppedItem, spawnLocation, Quaternion.identity);
                lootGO.GetComponent<SpriteRenderer>().sprite = loot.itemIcon;
            }
            // GameObject lootGO = Instantiate(droppedItem, spawnLocation, Quaternion.identity);
            // lootGO.GetComponent<SpriteRenderer>().sprite = droppedLoot.itemIcon;
        }
    } 
}
