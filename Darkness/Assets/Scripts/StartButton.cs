using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject LoadGame;
    // Start is called before the first frame update

    public void OpenLoadGame()
    {
        if(LoadGame != null)
        {
            LoadGame.SetActive(true);
        }
    }
}
