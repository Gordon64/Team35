using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitBlock : MonoBehaviour
{
    [SerializeField]
    private GameObject heroBlock;

    [SerializeField]
    public List<GameObject> blockOptions;

    private GameObject currentBlock;

    //Manages player block actions
    void Awake()
    {
        this.heroBlock = Instantiate(this.heroBlock, this.transform);
        this.heroBlock.GetComponent<AttackTarget>().owner = this.gameObject;

        this.currentBlock = this.heroBlock;

        for (int i = 0; i < blockOptions.Count; i++)
        {
            blockOptions[i] = Instantiate(blockOptions[i], this.transform);
            blockOptions[i].GetComponent<AttackTarget>().owner = this.gameObject;
        }
    }

    public void selectBlock(GameObject newBlock)
    {
        this.currentBlock = newBlock;
    }

    public void basicBlock()
    {
        this.currentBlock = heroBlock;
    }

    public void updateHUD()
    {
        GameObject playerUnitHealthBar = GameObject.Find("PlayerHealthBar") as GameObject;
        playerUnitHealthBar.GetComponent<ShowUnitHealth>().changeUnit(this.gameObject);
        GameObject playerActionEnergyBar = GameObject.Find("PlayerActionEnergyBar") as GameObject;
        playerActionEnergyBar.GetComponent<ShowActionEnergy>().changeUnit(this.gameObject);
    }
}
