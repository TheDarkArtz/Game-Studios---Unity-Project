using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Load UI Canvas On Start")]
    public GameObject UI;
    public static int money = 0;
    
    void Awake() 
    {
        UI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
