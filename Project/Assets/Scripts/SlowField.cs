using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowField : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] AudioSource sludgeSound;

    private void Awake() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var movement = other.GetComponent<MovementHandler>();
            movement.groundDrag = 10f;
            audioSource.Play();
            sludgeSound.Play();
        }
  
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var movement = other.GetComponent<MovementHandler>();
            movement.groundDrag = 1.7f;
            sludgeSound.Stop();
        }
    }
}
