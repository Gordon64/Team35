using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_LoadGame : MonoBehaviour
{
    public GameObject LoadGame; //Panel for player to select their new or saved game files.
    public GameObject Exit_LoadGame; //Button to close the current panel.
    public GameObject SettingPanel;

    public void CloseLoadGame()
    {
        //Function to close panel and exit button
        if (LoadGame)
        {
            SettingPanel.SetActive(false);
            LoadGame.SetActive(false);
            Exit_LoadGame.SetActive(false);
        }
    }

}
