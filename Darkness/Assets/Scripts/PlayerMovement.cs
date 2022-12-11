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

        Vector2 currentVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;

        float newVelocityX = 0f; 

        //flips sprite based on direction walked
        if (moveHorizontal > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveHorizontal < 0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //moving left & right
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

        //running animator
        gameObject.GetComponent<Animator>().SetBool("running", moveHorizontal != 0);



        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(newVelocityX, 0);
    }




}
