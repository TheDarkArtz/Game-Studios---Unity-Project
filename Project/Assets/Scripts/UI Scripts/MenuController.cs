using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    public PlayerInputManager playerInputManager;

    [Header("Scene Crossfade Controls")]
    [SerializeField] private Animator crossFadeTransistion;
    [SerializeField] private float transistionTime = 2;
    [SerializeField] private Animator musicFadeTransistion;
    private AudioSource audioSource;

    [Header("Menu Transitions")]
    [SerializeField] private Animator camaraTransistion;
    [SerializeField] private Animator menuTransistion;

    private void Awake() 
    {
        // Displays the mouse, but locks it to the game screen.
        Cursor.lockState = CursorLockMode.Confined;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        
    }

    public void CharacterSelectMenu()
    {
        camaraTransistion.SetTrigger("StartChr");
        menuTransistion.SetTrigger("GoToChr");
        playerInputManager.EnableJoining();
    }

    public void BackToMainMenu()
    {
        camaraTransistion.SetTrigger("StartMenu");
        menuTransistion.SetTrigger("GoToMenu");
        playerInputManager.DisableJoining();
    }

    //The play game event. Called by the play game button.
    public void PlayGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

        //The quit game event. Called by the quit game button.
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        crossFadeTransistion.SetTrigger("Start");
        musicFadeTransistion.SetTrigger("StartFade");

        yield return new WaitForSeconds(transistionTime);

        SceneManager.LoadScene(levelIndex);
    }    
}
