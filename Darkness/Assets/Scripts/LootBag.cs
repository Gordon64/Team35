using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{

    public GameObject droppedItem;
    public List<InventoryItem> lootList = new List<InventoryItem>();

    //gets items to be dropped
    // List<InventoryItem> obtainItemsDropped(){
    //     int randomNumber = Random.Range(1, 101);
    //     List<InventoryItem> potentialDrops = new List<InventoryItem>();
    //     foreach(InventoryItem loot in lootList){
    //         if(randomNumber <= loot.probability){
    //             potentialDrops.Add(loot);
    //             return potentialDrops;
    //         }
    //     }
    InventoryItem obtainItemDropped(){
        int randomNumber = Random.Range(1, 101);
        List<InventoryItem> potentialDrop = new List<InventoryItem>();
        foreach(InventoryItem loot in lootList){
            if(randomNumber <= loot.probability){
                potentialDrop.Add(loot);
            }
        }

        if (potentialDrop.Count > 0){
            InventoryItem theItem = potentialDrop[Random.Range(0, potentialDrop.Count)];
            return theItem;
        }

        //if no loot dropped
        Debug.Log("Loot was not dropped.");
        return null;
    }

    // public void InstantiateLoot(Vector3 spawnLocation){
    //     List<InventoryItem> droppedLoot =  obtainItemsDropped();
    //     if (droppedLoot != null){
    //         foreach(InventoryItem loot in droppedLoot){
    //             GameObject lootGO = Instantiate(droppedItem, spawnLocation, Quaternion.identity);
    //             lootGO.GetComponent<SpriteRenderer>().sprite = loot.itemIcon;
    //         }
    //         // GameObject lootGO = Instantiate(droppedItem, spawnLocation, Quaternion.identity);
    //         // lootGO.GetComponent<SpriteRenderer>().sprite = droppedLoot.itemIcon;
    //     }
    // } 

    public void InstantiateLoot(Vector3 spawnLocation){
        InventoryItem theItem =  obtainItemDropped();
        if (theItem != null){
                GameObject lootGO = Instantiate(droppedItem, spawnLocation, Quaternion.identity);
                lootGO.GetComponent<SpriteRenderer>().sprite = theItem.itemIcon;

                // float dropWeight = 300f;
                // Vector2 dropDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                // lootGO.GetComponent<Rigidbody2D>().AddForce(dropDir * dropWeight, ForceMode2D.Impulse);
        }
    } 
}
