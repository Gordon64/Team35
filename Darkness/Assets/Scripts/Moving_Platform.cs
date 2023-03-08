using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 1f;
    public float pauseDuration = 1f;

    private bool movingToA = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PauseBeforeSwitching());
    }

    // Update is called once per frame
    void Update()
    {
       if (movingToA)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
            if (transform.position == pointA.position)
            {
                movingToA = false;
                StartCoroutine(PauseBeforeSwitching());
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            if (transform.position == pointB.position)
            {
                movingToA = true;
                StartCoroutine(PauseBeforeSwitching());
            }
        } 
    }
    IEnumerator PauseBeforeSwitching(){
        yield return new WaitForSecondsRealtime(pauseDuration);
    }
}
