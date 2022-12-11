using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Animator animator;


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");     //moving left to right
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 currentVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;

        float newVelocityX = 0f;
        float newVelocityY = 0f;    

        if(moveHorizontal < 0 && currentVelocity.x <= 0)
        {
            newVelocityX = -speed;
            //animator for left goes here
        }
        else if (moveHorizontal > 0 && currentVelocity.x >= 0)
        {
            newVelocityX = speed;
            //animator for right goes here
        }
        else
        {
            //idle animation
        }

        if(moveVertical > 0 && currentVelocity.y >= 0)
        {
            newVelocityY = speed;
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(newVelocityX, 0);
    }

}
