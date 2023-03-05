using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Platform : MonoBehaviour
{
    public GameObject player;
    Keyboard keyboard;
    

    private void Start()
    {
        keyboard = Keyboard.current;

    }

    private void OnTriggerEnter(Collider other)
    {
        player.transform.parent = transform;
    }
    /*private void OnTriggerExit(Collider other)
    {
        player.transform.parent = null;
    }*/
    private void Update()
    {
        if (keyboard.spaceKey.isPressed)
        player.transform.parent = null;

    }
}

