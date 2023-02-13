using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public int damage;
    public Bandit playerHealth;


    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float movespeed = 5f;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
        
        health = maxHealth;
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        if (health != maxHealth)
        {
            move(movement);
            if (movement == Vector2.left)
            {
                GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponentInChildren<SpriteRenderer>().flipX = true;
            }
        }
        
    }

    public void takeDamage(int damageTaken)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.takeDamage(damage);
            takeDamage(damage);
            StartCoroutine(FlashRed());
        }
    }

    public IEnumerator FlashRed()
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.2f);
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }

    void move(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * movespeed * Time.deltaTime));
    }

    
}
