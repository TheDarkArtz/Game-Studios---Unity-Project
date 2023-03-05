using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public GameObject door;
    private bool isOpen;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            isOpen = true;
            door.transform.position += new Vector3(0, 4, 0);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            isOpen = false;
            door.transform.position -= new Vector3(0, 4, 0);
        }
    }

}