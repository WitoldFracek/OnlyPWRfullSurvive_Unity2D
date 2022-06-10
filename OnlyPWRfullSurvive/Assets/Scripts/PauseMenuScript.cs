using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{

    public static bool isGamePaused = false;
    [SerializeField] InputActionMap actionMap;
    [SerializeField] GameObject pauseMenu;

    void Start()
    {
        actionMap["Pause"].performed += ctx => TogglePauseMenu();
    }

    
    void Update()
    {
        
    }

    private void OnEnable()
    {
        actionMap.Enable();
    }

    private void OnDisable()
    {
        actionMap.Disable();
    }

    private void TogglePauseMenu()
    {
        if (isGamePaused)
        {
            ResumeGame();
        } else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }


}
