using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private PlayerInputManager manager;

    private void Awake() {
       DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        //manager.JoinPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
