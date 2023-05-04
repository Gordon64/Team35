using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowActionEnergy : ShowUnitStat
{
    override protected float newStatValue()
    {
        if (unit != null)
        {
            maxValue = unit.GetComponent<UnitStats>().maxEnergy;
        }

        textElement.text = "Energy - " + unit.GetComponent<UnitStats>().energy.ToString("#.") + "/" + unit.GetComponent<UnitStats>().maxEnergy.ToString("#.");
        return unit.GetComponent<UnitStats>().energy;
    }   
}
