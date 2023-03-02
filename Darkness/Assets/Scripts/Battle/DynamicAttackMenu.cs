using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DynamicAttackMenu : MonoBehaviour
{
    private List<GameObject> attacksList;

    public GameObject buttonTemplate;
    public Transform buttonContainer;

    void Start()
    {
        GameObject playerParty = GameObject.Find("PlayerParty");
        attacksList = playerParty.GetComponentInChildren<PlayerUnitAction>().attacks;

        foreach (GameObject attack in attacksList)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            button.GetComponentInChildren<TMP_Text>().text = attack.name;
            button.transform.SetParent(buttonContainer, false);

            Button objButton = button.GetComponent<Button>();
            objButton.onClick.AddListener(delegate { playerParty.GetComponent<SelectUnit>().selectAttack(attack); });
        }
    }
}
