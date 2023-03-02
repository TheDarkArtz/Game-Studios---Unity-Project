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

    public List<InputDevice> devices = new List<InputDevice>();

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

        devices.Add(input.devices[0]);

        currentAmountOfPlayers++;
        characterSelectPanel[currentAmountOfPlayers - 1].SetActive(false);
    }

    public void OnPlayerLeft()
    {

    }

    [ContextMenu("Do Something")]
    public void stuff()
    {
        foreach(var x in devices)
        {
            print(x);
        }
    }

    private void UpdateCharacter(int CharacterToChange, int selectedCharacter)
    {
        playerCharacterInt[CharacterToChange] = selectedCharacter;
    }
}
