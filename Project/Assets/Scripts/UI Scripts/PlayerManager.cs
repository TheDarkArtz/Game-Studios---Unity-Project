using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

[Serializable]
public struct materialChanger
{
    public Material[] mat;
}
public class PlayerManager : MonoBehaviour
{
    public materialChanger[] allMaterials;
    
    public int[] playerCharacterInt = new int[] {0,0,0,0};
    [SerializeField] private Transform[] SpawnLocations;

    [Range(0,4)]
    public int currentAmountOfPlayers = 0;
    public GameObject[] characterSelectPanel;
    public InputDevice[] device = new InputDevice[] {null,null,null,null};



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
        script.thisPlayersMaterial = allMaterials[currentAmountOfPlayers].mat;

        device[currentAmountOfPlayers] = input.devices[0];

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
