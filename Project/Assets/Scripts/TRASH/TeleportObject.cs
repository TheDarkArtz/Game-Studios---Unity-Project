using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObject : MonoBehaviour
{
    public Transform teleportProp;
    public GameObject warppableProp;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Scrap") || (other.CompareTag("CraftedScrap")))
        other.transform.position = teleportProp.transform.position;
    }
}
