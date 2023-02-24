using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJoiner : MonoBehaviour
{
    private PlayerInputManager playerInputManager;

    private void Awake() {
        playerInputManager = gameObject.GetComponent<PlayerInputManager>();
    }

    public void OnPlayerJoined(PlayerInput playerInput) 
    {
        print("why god whyyyyy");
    }
}
