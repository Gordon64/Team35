using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item in Inventory", menuName = "New Item")]
public class InventoryItem :ScriptableObject
{
    public int itemid;
    public string itemName;
    public int ourValue;
    public Sprite itemIcon;
    public ItemType itemType;
    public int shopCost;

    //loot test
    public int probability;


    [TextArea]
    public string itemDescription;

    public enum ItemType{
        Basic_Potion,
        Basic_Sword,
        Small_Money,
        Average_Money,
        Big_Money,
        Defense_Potion,
        Energy_Potion
    }
}
