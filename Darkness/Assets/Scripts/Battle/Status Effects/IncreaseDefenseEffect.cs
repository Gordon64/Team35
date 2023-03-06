using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Increase Defense Status Effect", menuName = "Status Effects/IncreaseDefense")]
public class IncreaseDefenseEffect : StatusEffect
{
    public int increaseDefenseAmount;

    public override void OnTurnStart(UnitStats unit)
    {
        unit.increasedDefense(increaseDefenseAmount, false);
        duration--;
    }
}
