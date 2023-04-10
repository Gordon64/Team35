using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float movespeed;

    [SerializeField]
    private Vector3[] positions;

    private int index = 0;

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * movespeed);

        Vector3 direction = positions[index] - transform.position;
        direction.Normalize();
        if (direction == Vector3.left)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }

        if (transform.position == positions[index])
        {
            if (index == positions.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
    }
}
