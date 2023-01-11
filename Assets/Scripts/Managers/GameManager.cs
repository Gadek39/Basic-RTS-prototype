using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveData;

public class GameManager : MonoBehaviour, ISaveData
{
    public static GameManager instance;
    public bool hasStartedGame;
    public bool isPaused;
    public float milk = 0;
    public float food = 0;
    public float shield = 0;
    public List<UnitData> units = new List<UnitData>();
    public List<GameObject> UnitsToActivate = new List<GameObject>();
    public Vector3 cameraPos;
    public Quaternion cameraRot;
    public List<GameObject> allUnits = new List<GameObject>();
    public GameObject startingUnit;
    public bool newGameStarted;


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
        
    public void SaveData (SaveData data)
    {
        data.food = food;
        data.shield = shield;
        data.milk = milk;
        data.units = units;
        data.cameraPos = cameraPos;
        data.cameraRot = cameraRot;
        Debug.Log("Save Data");
    }
    public void LoadData (SaveData data)
    {
        milk = data.milk;
        food = data.food;
        shield = data.shield;
        units = data.units;
        cameraPos = data.cameraPos;
        cameraRot = data.cameraRot;
        Debug.Log("Load Data");
    }
    public void showInventoryStatus()
    {
        Debug.Log("Current resources:\nMilk - " + milk + "\nFood - " + food + "\nSafety - " + shield);
    }
    public void LoadSavedDataForUnits()
    {
            foreach (UnitData data in units)
            {
                if (data.isActive)
                    UnitsToActivate.Add(GameObject.Find(data.name));
            }
            foreach (GameObject activeUnit in UnitsToActivate)
            {
                activeUnit.SetActive(true);
                Debug.Log(activeUnit.name);
            }
    }
    public void PrepareStartingUnits()
    {
        allUnits = new List<GameObject>();
        foreach (GameObject eachUnit in FindObjectsOfType<GameObject>())
        {
            if (eachUnit.tag == "unit" && eachUnit.name != "Unit")
            {
                allUnits.Add(eachUnit);
            }
        }
        foreach (GameObject everyUnit in allUnits)
        {
            Debug.Log(everyUnit.name);
            everyUnit.SetActive(false);
        }
        newGameStarted = false;
    }
}
