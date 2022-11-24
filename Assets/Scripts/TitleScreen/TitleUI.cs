using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
#if UNITY_EDITOR
using UnityEngine;
#endif
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    [SerializeField] Button saveButton;
    [SerializeField] GameObject saveMenu;
    [SerializeField] GameObject loadMenu;
    public int currentSaveSlot;

    // Start is called before the first frame update
    void Start()
    {
        resumeButton.interactable = false;
        saveButton.interactable = false;
        if (GameManager.instance.hasStartedGame)
        {
            SetPauseMenu();
        }
        loadMenu.SetActive(false);
        saveMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SaveManager.Instance.NewGame();
        SceneManager.LoadScene(1);
        GameManager.instance.hasStartedGame = true;
    }
    public void ResumeGame()
    {
        GameManager.instance.isPaused = false;
        SceneManager.UnloadSceneAsync(0);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void SaveMenu()
    {
        if (saveMenu.activeInHierarchy)
        {
            saveMenu.SetActive(false);
        }
        else if (!saveMenu.activeInHierarchy)
        {
            saveMenu.SetActive(true);
        }
    }
    public void LoadMenu()
    {
        if (loadMenu.activeInHierarchy)
        {
            loadMenu.SetActive(false);
        }
        else if (!loadMenu.activeInHierarchy)
        {
            loadMenu.SetActive(true);
        }
    }
    public void SaveGameSlot()
    {
        SaveManager.Instance.SaveGame(currentSaveSlot);
    }
    public void LoadGameSlot()
    {
        SaveManager.Instance.LoadGame(currentSaveSlot);
        SceneManager.LoadScene(1);
    }
    private void SetPauseMenu()
    {
        resumeButton.interactable = true;
        saveButton.interactable = true;
    }
}
