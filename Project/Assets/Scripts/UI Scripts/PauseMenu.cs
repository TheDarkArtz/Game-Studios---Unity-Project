using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    private static bool gameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject gameUI;
    
    private PlayerControls controls;

    private void Awake() 
    {
        controls = new PlayerControls();
        controls.Menu.Start.performed += ctx => Pause();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        AudioListener.pause = false;
        gameIsPaused = false;
    }

    void Pause()
    {
        if(gameIsPaused == true)
        {
            Resume();
        }
        else
        {
            pauseMenuUI.SetActive(true);
            gameUI.SetActive(false);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
            AudioListener.pause = true;
            gameIsPaused = true;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        AudioListener.pause = false;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Confined;
        AudioListener.pause = false;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void DebugNextScene()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Confined;
        AudioListener.pause = false;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void OnEnable() 
    {
        controls.Menu.Enable();
    }

    private void OnDisable() 
    {
        controls.Menu.Disable();
    }
}