using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject gameUI;

    void Update()
    {
        // if (however i get the start button in the new Input method.)
        //{
            //if(gameIsPaused == true)
            //{
                //Resume();
           // }
       // }
      //  else
       // {
       //     {
       //         Pause();
       //     }
      //  }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;
        Cursor.visible = false;
        AudioListener.pause = false;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0f;
        Cursor.visible = true;
        AudioListener.pause = true;
        gameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

}