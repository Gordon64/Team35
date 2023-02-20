using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffectAction : StatusEffect
{
    public string actionName;

    public virtual void OnAction(UnitStats unit)
    {
        //Implement an effect that triggers in repsponse to an action ie. unit takes bleed damage when attacking
    }
}
