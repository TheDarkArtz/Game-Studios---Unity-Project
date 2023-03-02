using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJoiner : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    private int playerAmount;
    [SerializeField] private Transform[] SpawnLocations;
    private PlayerManager playerManager;

    private void Awake() 
    {
        playerInputManager = gameObject.GetComponent<PlayerInputManager>();
        playerManager = FindObjectOfType<PlayerManager>();
        playerAmount = playerManager.currentAmountOfPlayers;

        for (var i = 0; i < playerAmount; i++)
        {
            playerInputManager.JoinPlayer(i,-1,null,pairWithDevice: playerManager.device[i]);
        }

    }

    public void OnPlayerJoined(PlayerInput playerInput) 
    {
        MovementHandler player = playerInput.gameObject.GetComponent<MovementHandler>();
        player.id = playerInput.playerIndex;
        player.spawnPoint = SpawnLocations[playerInput.playerIndex];
        player.selectedCharacter = playerManager.playerCharacterInt[playerInput.playerIndex];

    }
}
