using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedInfo
{
    public float health;
    public Vector3 position;

    public SavedInfo(){
        this.health = 30.0f;
        position = Vector3.zero;
    }
}
