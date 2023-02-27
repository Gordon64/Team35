using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitAction : MonoBehaviour
{
    [SerializeField]
    private string targetsTag;

    [SerializeField]
    public List<GameObject> attacks;

    void Awake()
    {
        foreach (GameObject attack in attacks)
        {
            attack.GetComponent<AttackTarget>().owner = this.gameObject;
        }
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
