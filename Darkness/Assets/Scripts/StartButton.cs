using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD

public class StartButton : MonoBehaviour
{
    public GameObject LoadGame; //Panel for player to select their new or saved game files.
    public GameObject Close_LoadGame; //Button to close the current panel.

    //Function to open panel when "Start" button is pressed.
    public void OpenLoadGame()
    {
        //Function to display panel and exit button
        if(LoadGame != null)
        {
            LoadGame.SetActive(true);
        }

        if (Close_LoadGame != null)
        {
            Close_LoadGame.SetActive(true);
        }
=======
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void loadNextScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
>>>>>>> John-Dev-Branch
    }
}
