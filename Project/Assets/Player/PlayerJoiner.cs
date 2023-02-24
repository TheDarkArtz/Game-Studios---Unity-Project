using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJoiner : MonoBehaviour
{
    public void OnPlayerJoined(PlayerInput playerInput) 
    {
        print("why god whyyyyy");
        gameObject.GetComponent<PlayerInputManager>().JoinPlayer();
    }
}
