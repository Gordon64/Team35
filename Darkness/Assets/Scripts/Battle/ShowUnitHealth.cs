using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUnitHealth : ShowUnitStat
{
    override protected float newStatValue()
    {
        if (unit != null)
        {
            maxValue = unit.GetComponent<UnitStats>().maxHealth;
        }

        textElement.text = "HP - " + unit.GetComponent<UnitStats>().health.ToString("#.") + "/" + unit.GetComponent<UnitStats>().maxHealth.ToString("#.");
        return unit.GetComponent<UnitStats>().health;
    }   
}
