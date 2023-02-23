using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    private void Awake() 
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void PlayAgain()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex -1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
