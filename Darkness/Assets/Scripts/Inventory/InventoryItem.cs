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
}
