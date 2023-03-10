using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{

    public GameObject door2;
    private Vector3 OpenPos2;
    private Vector3 ClosePos2;
    private int PlayersPad;
    public int PlayerCountGoal;
    private AudioSource audioSource;


    private void Awake() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        OpenPos2 = door2.transform.position + (Vector3.up * 4);
        ClosePos2 = door2.transform.position;
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

    private void OnEnable() 
    {
        Button.Button2Pressed += Door2Open;
        Button.Button2NotPressed += Door2Close;
    }

    private void OnDisable() 
    {
        Button.Button2Pressed -= Door2Open;
        Button.Button2NotPressed -= Door2Close;
    }

}