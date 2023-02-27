using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int[] playerCharacterInt = new int[] {0,0,0,0};
    [SerializeField] private Transform[] SpawnLocations;
    [SerializeField] private int currentAmountOfPlayers = 0;
    public GameObject[] characterSelectPanel;

    private void Awake() 
    {
        DontDestroyOnLoad(this);
    }

    public void OnPlayerJoined(PlayerInput input)
    {
        LoadCharacter script = input.gameObject.GetComponent<LoadCharacter>();
        script.id = input.playerIndex;
        script.spawnPoint = SpawnLocations[input.playerIndex];
        script.OnCharacterChanged += UpdateCharacter;

        currentAmountOfPlayers++;
        characterSelectPanel[currentAmountOfPlayers - 1].SetActive(false);
    }

    public void OnPlayerLeft()
    {

    }

    private void UpdateCharacter(int CharacterToChange, int selectedCharacter)
    {
        playerCharacterInt[CharacterToChange] = selectedCharacter;
    }
}
