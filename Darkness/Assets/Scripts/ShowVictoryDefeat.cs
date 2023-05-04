using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowVictoryDefeat : MonoBehaviour
{
    public GameObject victoryScreen;
    public GameObject defeatScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowVictoryScreen()
    {
        StartCoroutine(Victory());
    }

    public void ShowDefeatScreen()
    {
        StartCoroutine(Defeat());
    }

    IEnumerator Victory()
    {
        victoryScreen.SetActive(true);
        yield return new WaitForSeconds(2);
        victoryScreen.SetActive(false);
    }

    IEnumerator Defeat()
    {
        defeatScreen.SetActive(true);
        yield return new WaitForSeconds(2);
        defeatScreen.SetActive(false);
    }
}
