using UnityEngine;
using TMPro;

public class StatsSet : MonoBehaviour
{
    public TextMeshProUGUI healthStat;
    public TextMeshProUGUI attackStat;
    public TextMeshProUGUI defenseStat;
    public TextMeshProUGUI energyStat;

    public UnitStats Player;
    private void Start()
    {
        Player = FindObjectOfType<UnitStats>();
    }

    public void SetStats()
    {
        float playerHealth = Player.maxHealth;
        float playerAttack = Player.attack;
        float playerDefense = Player.defense;
        float playerEnergy = Player.energy;

        healthStat.text = System.Convert.ToString(playerHealth);
        attackStat.text = System.Convert.ToString(Player.attack);
        defenseStat.text = System.Convert.ToString(Player.defense);
        energyStat.text = System.Convert.ToString(Player.maxEnergy);
    }

//Update so that values can change
    void Update()
    {
        SetStats();
    }
}
