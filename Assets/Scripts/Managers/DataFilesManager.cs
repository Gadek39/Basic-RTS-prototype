using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataFilesManager 
{
    private string directory;
    private string fileName;

    public DataFilesManager (string directory, string fileName)
    {
        this.directory = directory;
        this.fileName = fileName;
    }   
    public void Save(SaveData data)
    {
        string fullPath = Path.Combine(directory, fileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            string dataToStore = JsonUtility.ToJson(data);
            Debug.Log("Data saved to " + fileName + "\n" + dataToStore);
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }

        }
        catch (Exception e)
        {
            Debug.Log("Couldn't save data under " + fullPath + "\n" + fileName + "\n" + e);
        }

    }
    public SaveData Load()
    {
        string fullPath = Path.Combine(directory, fileName);
        SaveData loadedData = null;
        if (File.Exists(fullPath))
        {
            try 
            {
                string dataToLoad;
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                loadedData = JsonUtility.FromJson<SaveData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.Log("Failed to load data under " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }
}
