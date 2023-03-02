using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LoadCharacter : MonoBehaviour
{
    public delegate void CharacterHandler(int CharacterToChange, int selectedCharacter);
    public event CharacterHandler OnCharacterChanged;

    [SerializeField] private GameObject[] characters;
    
    public Transform spawnPoint;
    public int id = 0;
    [SerializeField] private int selectedCharacter = 0;

    private bool Ready = false;

    private void Start() {
        transform.position = spawnPoint.position;
        characters[selectedCharacter].SetActive(true);
    }

    public void SelectCharacter(InputAction.CallbackContext context)
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
            OnCharacterChanged?.Invoke(id,selectedCharacter);
        }
    }

    public void ReadyCharacter(InputAction.CallbackContext context)
    {
        Ready = true;
    }
}
