using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            PauseGame();
        } else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }


}
