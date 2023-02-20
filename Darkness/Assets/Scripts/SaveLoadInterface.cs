using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SaveLoadInterface 
{
    void LoadData(SavedInfo info);
    void SaveData(SavedInfo info);
}