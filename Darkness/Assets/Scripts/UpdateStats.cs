using UnityEngine;
using TMPro;

public class UpdateStats : MonoBehaviour
{
    public TextMeshProUGUI statValue;
    public TextMeshProUGUI numUpgrades;
    public Bandit Bandit;
    public Shop_Manager Money;

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
            Money.TutPlayerWallet = Money.TutPlayerWallet - 2;

            if ((value - 5) == Bandit.health)
            {
                Bandit.health = Bandit.health + 5;
            }
        
        }
        
    }
}
