using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowField : MonoBehaviour
{
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var movement = other.GetComponent<MovementHandler>();
            movement.groundDrag = 3.5f;
        }
  
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var movement = other.GetComponent<MovementHandler>();
            movement.groundDrag = 1.7f;
        }
    }
}
