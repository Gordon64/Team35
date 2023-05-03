using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePlayerPos : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1 && SceneManager.GetActiveScene().name != "Tutorial")
        {
            float pX = player.transform.position.x;
            float pY = player.transform.position.y;

            pX = PlayerPrefs.GetFloat("p_x");
            pY = PlayerPrefs.GetFloat("p_y");
            player.transform.position = new Vector2(pX, pY);
            UnityEngine.Debug.Log(player.transform.position);
            PlayerPrefs.SetInt("TimeToLoad", 0);
            PlayerPrefs.Save();
        }
    }

    //Call this function to save player's position
    public void PlayerPosSave()
    {
        if (player == null)
        {
            player = FindObjectOfType<Bandit>().gameObject;
        }

        PlayerPrefs.SetFloat("p_x", player.transform.position.x);
        PlayerPrefs.SetFloat("p_y", player.transform.position.y);
        PlayerPrefs.SetInt("Saved", 1);
        PlayerPrefs.Save();
    }

    //Call this function to load player's position
    public void PlayerPosLoad()
    {
        PlayerPrefs.SetInt("TimeToLoad", 1);
        PlayerPrefs.Save();
    }
}
