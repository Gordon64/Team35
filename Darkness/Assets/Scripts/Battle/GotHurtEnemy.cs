using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotHurtEnemy : MonoBehaviour
{
    private UnitStats enemyStats;
    private float health;

    Animator animator;

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        if (this.gameObject.CompareTag("EnemyUnit"))
        {
            enemyStats = this.gameObject.GetComponent<UnitStats>();

            health = enemyStats.health;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(health > enemyStats.health)
        {
            //animator.SetTrigger("Hurt");
        }
    }
}
