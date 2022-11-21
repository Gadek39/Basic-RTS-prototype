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

    [SerializeField] List<Button> saveButtons;
    [SerializeField] List<Button> loadButtons;
    // Start is called before the first frame update
    void Start()
    {
        resumeButton.interactable = false;
        saveButton.interactable = false;
        if (GameManager.instance.hasStartedGame)
        {
            SetPauseMenu();
        }
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
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void SaveGame()
    {
        SaveManager.Instance.SaveGame(1);
    }
    public void LoadGame()
    {
        SaveManager.Instance.LoadGame(1);
    }
    private void SetPauseMenu()
    {
        resumeButton.interactable = true;
        saveButton.interactable = true;
    }
}
