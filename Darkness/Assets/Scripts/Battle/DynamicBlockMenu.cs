using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DynamicBlockMenu : MonoBehaviour
{
    private List<GameObject> blockList;

    public GameObject buttonTemplate;
    public Transform buttonContainer;

    void Start()
    {
        GameObject playerParty = GameObject.Find("PlayerParty");
        blockList = playerParty.GetComponentInChildren<PlayerUnitBlock>().blockOptions;


        foreach (GameObject block in blockList)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            button.GetComponentInChildren<TMP_Text>().text = block.name;
            button.transform.SetParent(buttonContainer, false);

            Button objButton = button.GetComponent<Button>();
            objButton.onClick.AddListener(delegate { playerParty.GetComponent<SelectUnit>().selectBlock(block); });
        }
    }
}
