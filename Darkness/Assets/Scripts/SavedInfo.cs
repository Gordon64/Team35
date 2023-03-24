using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedInfo
{
    public int health;
    public Vector3 position;

    public SavedInfo(){
        this.health = 30;
        position = Vector3.zero;
    }
}
