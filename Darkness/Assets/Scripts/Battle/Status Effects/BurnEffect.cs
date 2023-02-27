using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Burn Status Effect", menuName = "Status Effects/Burn")]
public class BurnEffect : StatusEffect
{
    public int damagePerTurn;

    public override void OnTurnStart(UnitStats unit)
    {
        unit.receiveDamage(damagePerTurn);
        duration--;
    }
}
