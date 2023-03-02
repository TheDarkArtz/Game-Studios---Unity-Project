using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int[] playerCharacterInt = new int[] {0,0,0,0};
    [SerializeField] private Transform[] SpawnLocations;

    [Range(0,4)]
    public int currentAmountOfPlayers = 0;
    public GameObject[] characterSelectPanel;

<<<<<<< HEAD
    public List<InputDevice> devices = new List<InputDevice>();
=======
    public int[] playerId = new int[] {0,0,0,0};

>>>>>>> origin/Jack

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

<<<<<<< HEAD
        devices.Add(input.devices[0]);
=======
        //playerId[currentAmountOfPlayers] = input.playerIndex;

        var device = input.devices[0];

        Debug.Log(device);
>>>>>>> origin/Jack

        currentAmountOfPlayers++;
        characterSelectPanel[currentAmountOfPlayers - 1].SetActive(false);
    }

    public void OnPlayerLeft()
    {
        
    }

<<<<<<< HEAD
    [ContextMenu("Do Something")]
    public void stuff()
    {
        foreach(var x in devices)
        {
            print(x);
        }
    }
=======
>>>>>>> origin/Jack

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
