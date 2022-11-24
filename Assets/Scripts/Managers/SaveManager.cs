using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using File = System.IO.File;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

public class SaveManager : MonoBehaviour
{
    private SaveData saveData;
    public static SaveManager Instance;
    private List<ISaveData> savedObjects;
    public string fileName;
    public DataFilesManager dataFilesManager;
    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        savedObjects = FindAllSavedObjects();
        fileName = "saveslot0";
        dataFilesManager = new DataFilesManager(Application.persistentDataPath, fileName);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
            {
            savedObjects = FindAllSavedObjects();
            int slot = 4;
            dataFilesManager = new DataFilesManager(Application.persistentDataPath, fileName);
            SaveGame(slot);
        }
    }
    public void NewGame()
    {
        this.saveData = new SaveData();
    }
    public void SaveGame(int slotNumber)
    {
        fileName += slotNumber;
        foreach (ISaveData saveObj in savedObjects)
        {
            saveObj.SaveData(saveData);
        }

        dataFilesManager.Save(saveData);
    }
    public void LoadGame(int slotNumber)
    {
        fileName += slotNumber;

        this.saveData = dataFilesManager.Load();

        if (this.saveData == null)
        {
            Debug.Log("No save data found");
        }

        foreach (ISaveData saveObj in savedObjects)
        {
            saveObj.LoadData(saveData);
        }
    }
    private List<ISaveData> FindAllSavedObjects()
    {
        IEnumerable<ISaveData> savedObjects = FindObjectsOfType<MonoBehaviour>().OfType<ISaveData>();
        return new List<ISaveData>(savedObjects);
    }

}
