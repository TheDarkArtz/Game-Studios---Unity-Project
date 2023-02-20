using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    [Header("Scene Crossfade Controls")]
    [SerializeField] private Animator crossFadeTransistion;
    [SerializeField] private float transistionTime = 2;
    [SerializeField] private Animator musicFadeTransistion;
    private AudioSource audioSource;

    [Header("Menu Transitions")]
    [SerializeField] private Animator camaraTransistion;
    [SerializeField] private Animator menuTransistion;

    /* -- this really needed?
    [Header("")]
    [SerializeField] private GameObject[] characters;

    
    [Range(0, 4)]
    public int players;
    public int selectedCharacter = 0;
    */

    private void Awake() 
    {
        // Displays the mouse, but locks it to the game screen.
        Cursor.lockState = CursorLockMode.Confined;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        PlayerManager.OnJoined += joined;
    }

    public void CharacterSelectMenu()
    {
        camaraTransistion.SetTrigger("StartChr");
        menuTransistion.SetTrigger("GoToChr");
    }

    public void BackToMainMenu()
    {
        camaraTransistion.SetTrigger("StartMenu");
        menuTransistion.SetTrigger("GoToMenu");
    }

    private void joined()
    {
        
    }


    /*
    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter --;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }
    */

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
