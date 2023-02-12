using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitAction : MonoBehaviour
{
    [SerializeField]
    private GameObject attack1;
    [SerializeField]
    private GameObject attack2;
    [SerializeField]
    private GameObject attack3;
    [SerializeField]
    private GameObject attack4;


    [SerializeField]
    private string targetsTag;

    private List<GameObject> attacks;

    void Awake()
    {
        attacks = new List<GameObject>();

        this.attack1 = Instantiate(this.attack1);
        this.attack1.GetComponent<AttackTarget>().owner = this.gameObject;
        attacks.Add(attack1);
        this.attack2 = Instantiate(this.attack2);
        this.attack2.GetComponent<AttackTarget>().owner = this.gameObject;
        attacks.Add(attack2);
        this.attack3 = Instantiate(this.attack3);
        this.attack3.GetComponent<AttackTarget>().owner = this.gameObject;
        attacks.Add(attack3);
        this.attack4 = Instantiate(this.attack4);
        this.attack4.GetComponent<AttackTarget>().owner = this.gameObject;
        attacks.Add(attack4);
    }

    GameObject findRandomTarget()
    {
        GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag(targetsTag);

        if(possibleTargets.Length > 0)
        {
            int targetIndex = Random.Range(0, possibleTargets.Length);
            GameObject target = possibleTargets[targetIndex];

            return target;
        }

        return null;
    }

    public void act()
    {
        GameObject target = findRandomTarget();

        int attackIndex = Random.Range(0, attacks.Count);
        this.attacks[attackIndex].GetComponent<AttackTarget>().hit(target);
    }
}
