using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Shop_Trigger : MonoBehaviour
{
    public GameObject ShopPanel;
    public Dialogue tutorial;
    // Start is called before the first frame update
    void Start()
    {
        ShopPanel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (ShopPanel.activeSelf == false)
        {
            ShopPanel.SetActive(true);
            Bandit.Instance.shopEnabled = true;
            Bandit.Instance.rb2d.velocity = Vector2.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
