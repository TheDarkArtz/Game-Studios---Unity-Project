using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private PlayerInputManager manager;
    public LoadCharacter load1Character;
    public LoadCharacter load2Character;
    public LoadCharacter load3Character;
    public LoadCharacter load4Character;
    public int player1CharacterInt;
    public int player2CharacterInt;
    public int player3CharacterInt;
    public int player4CharacterInt;
    

    private void Awake() 
    {
       DontDestroyOnLoad(this);
       
       //manager.playerJoinedEvent
    }

    private void joined()
    {

    }

    private void Update() 
    {
        player1CharacterInt = load1Character.selectedCharacter;
        player2CharacterInt = load2Character.selectedCharacter;
        player3CharacterInt = load3Character.selectedCharacter;
        player4CharacterInt = load4Character.selectedCharacter;
    }
}
