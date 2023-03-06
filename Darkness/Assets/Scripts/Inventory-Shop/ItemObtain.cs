using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObtain : MonoBehaviour
{
    public InventoryItem anItem;

    void Obtain()
    {
        InventoryManager.Instance.Add(anItem);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Obtain();
    }
}
