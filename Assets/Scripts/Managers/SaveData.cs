using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
        public float food;
        public float milk;
        public float shield;
    
    public SaveData()
    {
        this.food = 0;
        this.milk = 0;
        this.shield = 0;
    }
}
