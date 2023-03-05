using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform teleportPoint;
    public GameObject warppableObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        other.transform.position = teleportPoint.transform.position;
    }
}
