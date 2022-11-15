using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, ISaveData
{
    public static GameManager instance;
    public bool hasStartedGame;
    public bool isPaused;
    public float milk = 0;
    public float food = 0;
    public float shield = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

    }
        
    public void SaveData (ref SaveData data)
    {
        data.food = this.food;
        data.shield = this.shield;
        data.milk = this.milk;
    }
    public void LoadData (SaveData data)
    {
        this.milk = data.milk;
        this.food = data.food;
        this.shield = data.shield;
    }
}
