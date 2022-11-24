using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSlot : MonoBehaviour
{
    [SerializeField] int slot;
    private TitleUI titleUI;

    private void Start()
    {
        titleUI = FindObjectOfType<TitleUI>();
    }


    public void OnClickedSave()
    {
        titleUI.currentSaveSlot = slot;
        SaveManager.Instance.dataFilesManager = new DataFilesManager(Application.persistentDataPath, SaveManager.Instance.fileName);
        titleUI.SaveGameSlot();
    }
    public void OnClickedLoad()
    {
        titleUI.currentSaveSlot = slot;
        SaveManager.Instance.dataFilesManager = new DataFilesManager(Application.persistentDataPath, SaveManager.Instance.fileName);
        titleUI.LoadGameSlot();
    }

}
