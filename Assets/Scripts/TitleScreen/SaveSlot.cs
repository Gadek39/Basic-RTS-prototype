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
        SaveManager.Instance.SaveGame(slot, SaveManager.Instance.fileName);
    }
    

}
