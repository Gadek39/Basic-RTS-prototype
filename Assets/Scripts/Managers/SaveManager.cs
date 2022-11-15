using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using File = System.IO.File;
using System.Linq;
using System.Runtime.CompilerServices;

public class SaveManager : MonoBehaviour
{
    private SaveData saveData;
    public static SaveManager Instance;
    private List<ISaveData> savedObjects;
    

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
    }
    public void NewGame()
    {
        this.saveData = new SaveData();
    }
    public void SaveGame()
    {
        foreach (ISaveData saveObj in savedObjects)
        {
            saveObj.SaveData(ref saveData);
        }

        Debug.Log("Saved\nMilk " + saveData.milk + "\n Food " + saveData.food + "\n Safety " + saveData.shield);
    }
    public void LoadGame()
    {
        foreach (ISaveData saveObj in savedObjects)
        {
            saveObj.LoadData(saveData);
        }
        Debug.Log("Loaded values\nMilk " + saveData.milk + "\n Food " + saveData.food + "\n Safety " + saveData.shield);

    }
    private List<ISaveData> FindAllSavedObjects()
    {
        IEnumerable<ISaveData> savedObjects = FindObjectsOfType<MonoBehaviour>().OfType<ISaveData>();
        return new List<ISaveData>(savedObjects);
    }

}
