using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject hero;
    public float xMinimum;
    public float xMaximum;
    public float yMinimum;
    public float yMaximum;

    void Start()
    {
        hero = GameObject.Find("LightBandit");
    }

    //we can adjust x and y values to the length of the map under this script in "Main Camera"
    void Update()
    {
        float x = Mathf.Clamp(hero.transform.position.x, xMinimum, xMaximum);
        float y = Mathf.Clamp(hero.transform.position.y, yMinimum, yMaximum);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
