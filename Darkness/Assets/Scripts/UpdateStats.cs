using UnityEngine;
using TMPro;

public class UpdateStats : MonoBehaviour
{
    public TextMeshProUGUI statValue;
    public TextMeshProUGUI numUpgrades;

    public void UpdateStat()
    {
        string statTemp = statValue.text;
        string numTemp = numUpgrades.text;

        int value = System.Convert.ToInt32(statTemp);
        int num = System.Convert.ToInt32(numTemp);

        if (num >= 1)
        {
            value = value + 5;
            statTemp = System.Convert.ToString(value);
            statValue.text = statTemp;

            num = num - 1;
            numTemp = System.Convert.ToString(num);
            numUpgrades.text = numTemp;
        }
        
    }
}
