using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect : ScriptableObject
{
    public string effectName;
    public string description;
    public Sprite icon;
    public int duration;
    [SerializeField]
    private int baseDuration;
    private bool updated;

    public virtual void ApplyEffect(UnitStats unit)
    {
        StatusEffect existingStatusEffect = unit.statusEffects.Find(se => se.GetType() == this.GetType());

        if(existingStatusEffect != null)
        {
            existingStatusEffect.IncreaseDuration(this.baseDuration);
        }
        else
        {
            this.duration = baseDuration;
            unit.statusEffects.Add(this);
        }
    }

    public virtual void RemoveEffect(UnitStats unit)
    {
        unit.statusEffects.Remove(this);
        this.duration = 0;
    }

    public virtual void OnTurnStart(UnitStats unit)
    {
        //implement effect ie. unitStats.takeDamage(damage);
    }

    public virtual void IncreaseDuration(int newDuration)
    {
        this.duration += newDuration;
    }

    public virtual void DecreaseDuration()
    {
        this.duration--;
    }
}
