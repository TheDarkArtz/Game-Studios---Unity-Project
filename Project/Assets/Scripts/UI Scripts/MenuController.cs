using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class MenuController : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    private PlayerManager playerManager;

    [Header("Scene Crossfade Controls")]
    [SerializeField] private Animator crossFadeTransistion;
    [SerializeField] private float transistionTime = 2;
    [SerializeField] private Animator musicFadeTransistion;
    private AudioSource audioSource;

    [Header("Menu Transitions")]
    [SerializeField] private Animator camaraTransistion;
    [SerializeField] private Animator menuTransistion;


    [Range(0,4)]
    private int numPlayersReady = 0;
    private int currentPlayers;
    [SerializeField] int requiredNumberOfPlayers = 2;

    public TMPro.TextMeshProUGUI playersReadyText;
    public TMPro.TextMeshProUGUI currentPlayersText;

    private void Awake() 
    {
        // Displays the mouse, but locks it to the game screen.
        Cursor.lockState = CursorLockMode.Confined;
        audioSource = GetComponent<AudioSource>();
        playerManager = FindObjectOfType<PlayerManager>();
    }

    private void Update() 
    {
        //tidy this up later
        currentPlayers = playerManager.currentAmountOfPlayers;
        currentPlayersText.text = "" + currentPlayers;
    }

    public void CharacterSelectMenu()
    {
        camaraTransistion.SetTrigger("StartChr");
        menuTransistion.SetTrigger("GoToChr");
        playerInputManager.EnableJoining();
    }

    public void BackToMainMenu()
    {
        numPlayersReady = 0;
        playerInputManager.DisableJoining();
        camaraTransistion.SetTrigger("StartMenu");
        menuTransistion.SetTrigger("GoToMenu");
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

    private void OnEnable() 
    {
        LoadCharacter.onReady += PlayerReady;
        LoadCharacter.onCancel += PlayerCanceled;
        LoadCharacter.onBack += BackToMainMenu;
    }

    private void OnDisable() 
    {
        LoadCharacter.onReady -= PlayerReady;
        LoadCharacter.onCancel -= PlayerCanceled;
        LoadCharacter.onBack -= BackToMainMenu;
    }

    void PlayerReady()
    {
        numPlayersReady += 1;
        playersReadyText.text = "" + numPlayersReady; 

        if (currentPlayers >= requiredNumberOfPlayers)
        {
            if (numPlayersReady == currentPlayers)
            {
                PlayGame();
            }
        }
    }

    void PlayerCanceled()
    {
        numPlayersReady -= 1;
        playersReadyText.text = "" + numPlayersReady;  
    }
}
