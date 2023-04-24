using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedInfo
{
    public float health;
    public Vector3 position;
    public float attack;
    public float defense;
    public float speed;
    public float energy;
    public float MaxHealth;
    public float MaxEnergy;

    public SavedInfo(){
        this.health = 30.0f;
        this.position = Vector3.zero;
        this.attack = 10.0f;
        this.defense = 5.0f;
        this.speed = 15.0f;
        this.energy = 10.0f;
        this.MaxHealth = 30.0f;
        this.MaxEnergy = 10.0f;
    }
}
