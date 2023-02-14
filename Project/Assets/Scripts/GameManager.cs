using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Load UI Canvas On Start")]
    public GameObject UI;

    void Awake() 
    {
        UI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
    
    }
}
