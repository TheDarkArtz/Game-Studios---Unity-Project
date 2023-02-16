using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{

    private void Awake() {
       DontDestroyOnLoad(this);
       
       //manager.playerJoinedEvent
    }

    private void joined()
    {

    }
}
