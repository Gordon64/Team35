using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemy;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject enemy in enemy)
        {
            enemy.SetActive(true);
        }

        //Testing purposes
        /*
        GameObject enemyObject = enemy.Find(obj => obj.name == "BatSpawner");
        enemyObject.SetActive(false);
        */
    }

    public void defeatedEnemy(string enemyName)
    {
        //GameObject enemyObject = enemy.Find(obj => obj.name == "BatSpawner");
        ////GameObject enemyObject = enemy.Find(obj => obj.name == enemyName);
        //Debug.Log("Enemy Name is: " + enemyName);
        //enemyObject.SetActive(false);
    }
}
