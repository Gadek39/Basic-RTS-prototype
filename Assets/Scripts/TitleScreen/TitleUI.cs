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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.instance.isPaused = false;
        SceneManager.UnloadSceneAsync(0);
        }
    }
    public void StartGame()
    {
        if (SceneManager.sceneCount == 2)
        {
            SceneManager.UnloadSceneAsync(1);
            Debug.Log("ok");
        }
        SaveManager.Instance.NewGame();
        SceneManager.LoadScene(1);
        GameManager.instance.hasStartedGame = true;
        GameManager.instance.newGameStarted = true;
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
    
    public void LoadGameSlot()
    {
    }
    private void SetPauseMenu()
    {
        resumeButton.interactable = true;
        saveButton.interactable = true;
    }
}
