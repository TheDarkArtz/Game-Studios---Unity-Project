using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public GameObject door;
    private Vector3 OpenPos;
    private Vector3 ClosePos;
    private int PlayersPad;
    public int PlayerCountGoal;
    public bool playerOnButton = false;
    public Door otherButton;

    private void Start()
    {
        OpenPos = door.transform.position + (Vector3.up * 4);
        ClosePos = door.transform.position;
    }

    void OnTriggerEnter(Collider col)
    {
        playerOnButton = true;

        if(col.gameObject.tag == "Player")
        {
            PlayersPad++;
            if (PlayersPad == PlayerCountGoal)
            {
                door.transform.position = OpenPos;

            }

        }
    }

    void OnTriggerExit(Collider col)
    {
        playerOnButton = false;

        if(col.gameObject.tag == "Player" & otherButton.playerOnButton != true)
        {
            PlayersPad--;
            if (PlayersPad < PlayerCountGoal)
            {
                door.transform.position = ClosePos;
            }

        }
    }

}