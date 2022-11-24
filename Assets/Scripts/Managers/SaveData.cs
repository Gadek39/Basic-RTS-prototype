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
        public bool isEating;
        public bool isResting;
        public Vector3 position;
        public Quaternion rotation;
    }
    public float food;
    public float milk;
    public float shield;
    public List<UnitData> units = new List<UnitData>();
    public Vector3 cameraPos;
    public Quaternion cameraRot;
    
    public SaveData()
    {
        food = 0;
        milk = 0;
        shield = 0;
        units = null;
        cameraPos = Vector3.zero;
        cameraRot = Quaternion.identity;
    }
}
