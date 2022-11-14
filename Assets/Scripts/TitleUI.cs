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
    private GameManager gameManager;
    [SerializeField] Button resumeButton;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        resumeButton.GetComponent<Button>().interactable = false;
        if (gameManager.hasStartedGame)
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
        SceneManager.LoadScene(1);
        gameManager.hasStartedGame = true;
    }
    public void ResumeGame()
    {
        gameManager.isPaused = false;
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
    private void SetPauseMenu()
    {
        resumeButton.interactable = true;
    }
}
