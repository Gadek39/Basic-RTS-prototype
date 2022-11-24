using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveData
{
    void LoadData(SaveData data);
    void SaveData(SaveData data);
}
