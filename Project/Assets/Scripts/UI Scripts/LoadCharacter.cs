using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LoadCharacter : MonoBehaviour
{
    public delegate void CharacterHandler(int CharacterToChange, int selectedCharacter);
    public event CharacterHandler OnCharacterChanged;

    [SerializeField] private GameObject[] characters;
    
    public Transform spawnPoint;
    public int id = 0;
    [SerializeField] private int selectedCharacter = 0;
    public Material[] thisPlayersMaterial;
    private Renderer rend;
    
    public delegate void ReadyAction();
    public static event ReadyAction onReady;
    public delegate void CancelAction();
    public static event CancelAction onCancel;
    public delegate void BackAction();
    public static event BackAction onBack;
    public bool playerReady = false;
    

    private void Start() 
    {
        transform.position = spawnPoint.position;
        characters[selectedCharacter].SetActive(true);
        rend = GetComponentInChildren<Renderer>();
        rend.material = thisPlayersMaterial[selectedCharacter];
    }

    public void SelectCharacter(InputAction.CallbackContext context)
    {
        if (playerReady == false)
        {
            if(context.performed)
            {
                characters[selectedCharacter].SetActive(false);
                selectedCharacter += (int) context.ReadValue<float>();
                if (selectedCharacter < 0)
                {
                    selectedCharacter += characters.Length;
                }
                else if (selectedCharacter > characters.Length - 1)
                {
                    selectedCharacter = 0;
                }
                characters[selectedCharacter].SetActive(true);
                rend = GetComponentInChildren<Renderer>();
                rend.material = thisPlayersMaterial[selectedCharacter];
                OnCharacterChanged?.Invoke(id,selectedCharacter);
            }
        }  
    }

    public void ReadyCharacter(InputAction.CallbackContext context)
    {
        if (playerReady == false)
        {
            onReady?.Invoke();
            playerReady = true;
        }
        else if (playerReady == true)
        {
            onCancel?.Invoke();
            playerReady = false;
        }
    }

    public void Back(InputAction.CallbackContext context)
    {
        onBack?.Invoke();
    }

    void DeletePlayers()
    {
        Destroy(gameObject);
    }

    private void OnEnable() 
    {
        LoadCharacter.onBack += DeletePlayers;
    }

    private void OnDisable() 
    {
        LoadCharacter.onBack -= DeletePlayers;
    }

}
