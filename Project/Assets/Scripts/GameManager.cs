using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Load UI Canvas On Start")]
    [SerializeField] private GameObject UI;

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
