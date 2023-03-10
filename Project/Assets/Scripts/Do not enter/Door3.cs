using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3 : MonoBehaviour
{
    public GameObject door3;
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
        OpenPos3 = door3.transform.position + (Vector3.up * 4);
        ClosePos3 = door3.transform.position;
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
        Button.Button3Pressed += Door3Open;
        Button.Button3NotPressed += Door3Close;
    }

    private void OnDisable() 
    {
        Button.Button3Pressed -= Door3Open;
        Button.Button3NotPressed -= Door3Close;
    }

}