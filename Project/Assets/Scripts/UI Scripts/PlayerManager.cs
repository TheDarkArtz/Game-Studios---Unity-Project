using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public delegate void joined();
    public static event joined OnJoined;

    //public LoadCharacter load1Character;
    //public LoadCharacter load2Character;
    //public LoadCharacter load3Character;
    //public LoadCharacter load4Character;

    public int[] playerCharacterInt = new int[] {0,0,0,0};
    [SerializeField] private Transform[] SpawnLocations;
    [SerializeField] private int currentAmountOfPlayers = 0;

    /*
    public int player1CharacterInt;
    public int player2CharacterInt;
    public int player3CharacterInt;
    public int player4CharacterInt;
    */

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
        OnJoined?.Invoke();
    }

    public void OnPlayerLeft()
    {
        
    }

    private void UpdateCharacter(int CharacterToChange, int selectedCharacter)
    {
        playerCharacterInt[CharacterToChange] = selectedCharacter;
    }
}
