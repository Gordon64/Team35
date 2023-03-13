using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yes_No_Script : MonoBehaviour
{
    public GameObject YesNoPanel;
    private Shop_Manager shopManager;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Shop");
        if(playerObject != null){
            shopManager = playerObject.GetComponent<Shop_Manager>();
        }
        else{
            UnityEngine.Debug.Log("can't find GameObject");
        }
    }

    public void YesButton(){
        if(shopManager.TutPlayerWallet >= 2){
            YesNoPanel.SetActive(false);
            shopManager.TutPlayerWallet = shopManager.TutPlayerWallet - 2;      //Figure out how to get the value from the selected Item and use that to subtract from the player wallet
            UnityEngine.Debug.Log(shopManager.TutPlayerWallet);
        }
        else{
            UnityEngine.Debug.Log("Not enough money!");
        }
    }

    public void NoButton(){
        YesNoPanel.SetActive(false);
    }
}
