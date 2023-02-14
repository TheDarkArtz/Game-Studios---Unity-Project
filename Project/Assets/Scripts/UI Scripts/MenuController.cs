using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Scene Crossfade Controls")]
    [SerializeField] private Animator crossFadeTransistion;
    [SerializeField] private float transistionTime = 2;
    [SerializeField] private Animator musicFadeTransistion;

    private AudioSource audioSource;

    private void Awake() 
    {
        Cursor.lockState = CursorLockMode.Confined;

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        crossFadeTransistion.SetTrigger("Start");
        musicFadeTransistion.SetTrigger("Start");

        yield return new WaitForSeconds(transistionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
