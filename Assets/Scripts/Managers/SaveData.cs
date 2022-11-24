using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    [System.Serializable]
    public struct UnitData
    {
        public string name;
        public bool isActive;
        public int energy;
        public int experience;
        public bool isWorking;
        public Vector3 position;
        public Quaternion rotation;
    }
    public float food;
    public float milk;
    public float shield;
    public List<UnitData> units = new List<UnitData>();
    
    public SaveData()
    {
        food = 0;
        milk = 0;
        shield = 0;
        units = null;
    }
}
