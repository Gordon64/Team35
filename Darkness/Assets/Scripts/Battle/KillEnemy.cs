using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public GameObject menuItem;
    public GameObject health;
    public GameObject healthText;

    void OnDestroy()
    {
        Destroy(this.menuItem);
        Destroy(this.health);
        Destroy(this.healthText);
    }
}
