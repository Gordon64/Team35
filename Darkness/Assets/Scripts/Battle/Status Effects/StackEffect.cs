using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stacking Status Effect", menuName = "Status Effects/Stack")]
public class StackEffect : StatusEffect
{
    public int stack;
    public int damage;

    public override void OnTurnStart(UnitStats unit)
    {
        this.stack++;

        if(stack > 3)
        {
            unit.receiveDamage(damage);
            this.stack = 0;
            this.duration--;
        }
    }
}
