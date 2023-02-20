using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage = 3;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemyStats>() != null)
        {
            EnemyStats enemy = collider.GetComponent<EnemyStats>();
            enemy.takeDamage(damage);
            //Vector2 direction = (collider.transform.position - enemy.transform.position).normalized;
            StartCoroutine(enemy.Knockback(0.02f, 500, enemy.transform.position));
        }
    }
}
