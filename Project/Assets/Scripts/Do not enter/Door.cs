using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public GameObject door1;
    private Vector3 OpenPos1;
    private Vector3 ClosePos1;
    private int PlayersPad;
    public int PlayerCountGoal;
    private AudioSource audioSource;


    private void Awake() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        OpenPos1 = door1.transform.position + (Vector3.up * 4);
        ClosePos1 = door1.transform.position;
    }

    void Door1Open()
    {
        PlayersPad++;
        if (PlayersPad == PlayerCountGoal)
        {
            door1.transform.position = OpenPos1;
            audioSource.Play();
        }
    }

    void Door1Close()
    {
            PlayersPad--;
            if (PlayersPad < PlayerCountGoal)
            {
                door1.transform.position = ClosePos1;
            }
    }


    private void OnEnable() 
    {
        Button.Button1Pressed += Door1Open;
        Button.Button1NotPressed += Door1Close;
    }

    private void OnDisable() 
    {
        Button.Button1Pressed -= Door1Open;
        Button.Button1NotPressed -= Door1Close;
    }

}