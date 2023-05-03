using UnityEngine;
using TMPro;

public class UpdateStats : MonoBehaviour
{
    public TextMeshProUGUI statValue;
    public TextMeshProUGUI numUpgrades;
    public Bandit Bandit;
    public Shop_Manager Money;
    public UnitStats Stats;

    public void UpdateStat()
    {
        numUpgrades.text = System.Convert.ToString(Money.TutPlayerWallet);

        string statTemp = statValue.text;
        string numTemp = numUpgrades.text;

        int value = System.Convert.ToInt32(statTemp);
        int num = System.Convert.ToInt32(numTemp);

        if (num >= 1)
        {
            value = value + 5;
            statTemp = System.Convert.ToString(value);
            statValue.text = statTemp;

            num = num - 2;
            Money.TutPlayerWallet -= 2;

            if (statValue.name == "Health Value")
            {
                Bandit.increaseHealth(5);
                Stats.increaseHealth(5);
            }

            if (statValue.name == "Attack Value")
            {
                //Bandit.increaseAttack(5);
                Stats.increaseAttack(5);
            }

            if (statValue.name == "Defense Value")
            {
                Bandit.increaseDefense(5);
                Stats.increaseDefense(5); 
            }

            if (statValue.name == "Energy Value")
            {
                //Bandit.increaseEnergy(5);
                Stats.increaseEnergy(5);
            }
        }
    }
}
