using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{

    [Header("Scene Crossfade Controls")]
    [SerializeField] private Animator crossFadeTransistion;
    [SerializeField] private float transistionTime = 2;
    [SerializeField] private Animator musicFadeTransistion;
    private AudioSource audioSource;
    private PlayerManager playerManager;
    private void Awake() 
    {
        Cursor.lockState = CursorLockMode.Confined;
        playerManager = FindObjectOfType<PlayerManager>();
    }
    public void PlayAgain()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    public void MainMenu()
    {
        StartCoroutine(LoadLevel(0));
        Destroy(playerManager.gameObject);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        crossFadeTransistion.SetTrigger("Start");
        musicFadeTransistion.SetTrigger("StartFade");

        yield return new WaitForSeconds(transistionTime);

        SceneManager.LoadScene(levelIndex);
    }

    
}
