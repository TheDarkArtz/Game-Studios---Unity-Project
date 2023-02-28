using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public int[] playerCharacterInt = new int[] {0,0,0,0};
    [SerializeField] private Transform[] SpawnLocations;

    [Range(0,4)]
    public static int currentAmountOfPlayers = 0;
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

    private void OnEnable() 
    {
        LoadCharacter.onBack += PlayersDeleted;
    }

    private void OnDisable() 
    {
        LoadCharacter.onBack -= PlayersDeleted;
    }

    void PlayersDeleted()
    {
        currentAmountOfPlayers = 0;
        for (var i = 0; i < characterSelectPanel.Length; i++)
        {
            characterSelectPanel[i].SetActive(true);
        }
    }
}
