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
    }

    public void NewGame()
    {
        saveData = new SaveData();
        foreach (ISaveData saveObj in savedObjects)
        {
            saveObj.LoadData(saveData);
        }
        Debug.Log("Game Started");
    }
    public void SaveGame(int slotNumber, string filenName)
    {
        string saveName = fileName + slotNumber;
        dataFilesManager = new DataFilesManager(Application.persistentDataPath, saveName);
        foreach (ISaveData saveObj in savedObjects)
        {
            saveObj.SaveData(saveData);
        }

        dataFilesManager.Save(saveData);
        Debug.Log("Game Saved");
    }
    public void LoadGame(int slotNumber, string filenName)
    {
        string saveName = fileName + slotNumber;
        dataFilesManager = new DataFilesManager(Application.persistentDataPath, saveName);

        this.saveData = dataFilesManager.Load();

        if (this.saveData == null)
        {
            Debug.Log("No save data found");
        }

        foreach (ISaveData saveObj in savedObjects)
        {
            saveObj.LoadData(saveData);
        }
        Debug.Log("Game Loaded");
    }
    private List<ISaveData> FindAllSavedObjects()
    {
        IEnumerable<ISaveData> savedObjects = FindObjectsOfType<MonoBehaviour>().OfType<ISaveData>();
        return new List<ISaveData>(savedObjects);
    }

}
