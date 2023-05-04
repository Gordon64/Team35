using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stacking Status Effect", menuName = "Status Effects/Stack")]
public class StackEffect : StatusEffect
{
    public int curStack;
    public int damage;
    public int stackProc;

    public override void OnTurnStart(UnitStats unit)
    {
        this.curStack++;

        if(curStack > 3)
        {
            unit.receiveDamage(damage, false);
            this.curStack = 0;
            this.duration--;
        }
    }

    public override void RemoveEffect(UnitStats unit)
    {
        unit.statusEffects.Remove(this);
        this.duration = 0;
        this.curStack = 0;
    }
}
