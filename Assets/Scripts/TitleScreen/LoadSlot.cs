using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSlot : MonoBehaviour
{
    [SerializeField] int slot;
    private TitleUI titleUI;
    public List<Unit> units = new List<Unit>();

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
        SaveManager.Instance.LoadGame(slot, SaveManager.Instance.fileName);
        SceneManager.LoadScene(1);
        GameManager.instance.hasStartedGame = true;
    }
}