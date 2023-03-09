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

    [Header("Scene Crossfade Controls")]
    [SerializeField] private Animator crossFadeTransistion;
    [SerializeField] private float transistionTime = 2;
    [SerializeField] private Animator musicFadeTransistion;
    [SerializeField] private AudioSource menuClick;
    [SerializeField] private AudioSource menuScroll;
    private PlayerManager playerManager;

    private void Awake() 
    {
        controls = new PlayerControls();
        controls.Menu.Start.performed += ctx => Pause();
        Cursor.lockState = CursorLockMode.Locked;
        playerManager = FindObjectOfType<PlayerManager>();
        menuClick.ignoreListenerPause = true;
        menuScroll.ignoreListenerPause = true;
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
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Confined;
        AudioListener.pause = false;
        StartCoroutine(LoadLevel(0));
        Destroy(playerManager.gameObject);
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
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        crossFadeTransistion.SetTrigger("Start");
        musicFadeTransistion.SetTrigger("StartFade");

        yield return new WaitForSeconds(transistionTime);

        SceneManager.LoadScene(levelIndex);
    }

    private void OnEnable() 
    {
        controls.Menu.Enable();
        Timer.OnTimeEnded += DebugNextScene;
    }

    private void OnDisable() 
    {
        controls.Menu.Disable();
        Timer.OnTimeEnded -= DebugNextScene;
    }


}