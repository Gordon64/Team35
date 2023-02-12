using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObtain : MonoBehaviour
{
    public InventoryItem Item;

    void Obtain()
    {
        InventoryManager.im.Add(Item);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Obtain();
    }
}
