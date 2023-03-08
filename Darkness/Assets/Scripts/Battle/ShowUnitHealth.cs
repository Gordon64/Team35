using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUnitHealth : ShowUnitStat
{
    override protected float newStatValue()
    {
        textElement.text = "HP - " + unit.GetComponent<UnitStats>().health.ToString("#.") + "/" + unit.GetComponent<UnitStats>().maxHealth.ToString("#.");
        return unit.GetComponent<UnitStats>().health;
    }   
}
