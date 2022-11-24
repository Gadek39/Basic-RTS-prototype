using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadSlot : MonoBehaviour
{
    [SerializeField] int slot;
    private TitleUI titleUI;

    private void Start()
    {
        GetComponent<Button>().interactable = false;
        titleUI = FindObjectOfType<TitleUI>();
    }

    private void Update()
    {
        if (System.IO.File.Exists(Path.Combine(Application.persistentDataPath, SaveManager.Instance.fileName + slot)))
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
    }
    public void OnClickedLoad()
    {
        titleUI.currentSaveSlot = slot;
        SaveManager.Instance.dataFilesManager = new DataFilesManager(Application.persistentDataPath, SaveManager.Instance.fileName);
        titleUI.LoadGameSlot();
    }
}