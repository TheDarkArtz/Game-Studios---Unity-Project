using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public delegate void DoorEvent();
    public static event DoorEvent Button1Pressed;
    public static event DoorEvent Button1NotPressed;
    public static event DoorEvent Button2Pressed;
    public static event DoorEvent Button2NotPressed;
    public static event DoorEvent Button3Pressed;
    public static event DoorEvent Button3NotPressed;

    private void OnTriggerEnter(Collider other) 
    {
        if (gameObject.tag == "buttons1")
        {  
            Button1Pressed?.Invoke();
        }
        else if (gameObject.tag == "buttons2")
        {
            Button2Pressed?.Invoke();
        }
        else if (gameObject.tag == "buttons3")
        {
            Button3Pressed?.Invoke();
        }
        
    }

    private void OnTriggerExit(Collider other) 
    {
        if (gameObject.tag == "buttons1")
        {  
            Button1NotPressed?.Invoke();
        }
        else if (gameObject.tag == "buttons2")
        {
            Button2NotPressed?.Invoke();
        }
        else if (gameObject.tag == "buttons3")
        {
            Button3NotPressed?.Invoke();
        }
        
    }
}
