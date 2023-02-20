using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionObtained : MonoBehaviour
{
    public Bandit bandit;
    // Start is called before the first frame update
    void Start()
    {
        bandit = FindObjectOfType<Bandit>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bandit.health += 3;
        Destroy(this.gameObject);
    }
}
