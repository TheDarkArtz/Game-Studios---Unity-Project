using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private PlayerInputManager manager;

    private void Awake() {
       DontDestroyOnLoad(this);
       
       //manager.playerJoinedEvent
    }

    private void joined()
    {

    }
}
