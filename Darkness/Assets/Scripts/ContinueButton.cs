using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    public GameObject LoadGamePanel; //Panel for player to select their new or saved game files.
    public GameObject Close_LoadGameButton; //Button to close the current panel.

    //Function to open panel when "Continue" button is pressed.
    public void OpenLoadGame()
    {
        //Function to display panel and exit button
        if (LoadGamePanel != null)
        {
            LoadGamePanel.SetActive(true);
        }

        if (Close_LoadGameButton != null)
        {
            Close_LoadGameButton.SetActive(true);
        }
    }

    public void ContinueClick(){
        StartNewGame.instance.LoadCorrectScene();
    }
}
