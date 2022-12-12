using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private float attackCooldown;
    private Animator an;
    private PlayerMovement pMove;
    private float cooldown = Mathf.Infinity;

    // 
    private void Awake()
    {
        //an = GetCompopnent<Animator>();
        //pMove = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && cooldown > attackCooldown )
        {
            Attack();
        }

        cooldown += Time.deltaTime;
    }

    private void Attack()
    {
        GetComponent<Animator>().SetTrigger("attack");
        cooldown = 0;
    }
}
