using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public delegate void Door1Event();
    public static event Door1Event Door1ButtonPressed;

    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    private Vector3 OpenPos1;
    private Vector3 ClosePos1;
    private Vector3 OpenPos2;
    private Vector3 ClosePos2;
    private Vector3 OpenPos3;
    private Vector3 ClosePos3;
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
        OpenPos2 = door2.transform.position + (Vector3.up * 4);
        ClosePos2 = door2.transform.position;
        OpenPos3 = door3.transform.position + (Vector3.up * 4);
        ClosePos3 = door3.transform.position;
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

    void Door2Open()
    {
        PlayersPad++;
        if (PlayersPad == PlayerCountGoal)
        {
            door2.transform.position = OpenPos2;
            audioSource.Play();
        }
    }

    void Door2Close()
    {
            PlayersPad--;
            if (PlayersPad < PlayerCountGoal)
            {
                door2.transform.position = ClosePos2;
            }
    }

    void Door3Open()
    {
        PlayersPad++;
        if (PlayersPad == PlayerCountGoal)
        {
            door3.transform.position = OpenPos3;
            audioSource.Play();
        }
    }

    void Door3Close()
    {
            PlayersPad--;
            if (PlayersPad < PlayerCountGoal)
            {
                door3.transform.position = ClosePos3;
            }
    }

    private void OnEnable() 
    {
        Button.Button1Pressed += Door1Open;
        Button.Button1NotPressed += Door1Close;
        Button.Button2Pressed += Door2Open;
        Button.Button2NotPressed += Door2Close;
        Button.Button3Pressed += Door3Open;
        Button.Button3NotPressed += Door3Close;
    }

    private void OnDisable() 
    {
        Button.Button1Pressed -= Door1Open;
        Button.Button1NotPressed -= Door1Close;
        Button.Button2Pressed -= Door2Open;
        Button.Button2NotPressed -= Door2Close;
        Button.Button3Pressed -= Door3Open;
        Button.Button3NotPressed -= Door3Close;
    }

}