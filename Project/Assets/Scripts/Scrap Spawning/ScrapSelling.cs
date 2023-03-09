using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapSelling : MonoBehaviour
{
    public delegate void MoneyHandler(int amount);
    public static event MoneyHandler OnMoneyAdded;
    private AudioSource audioSource;

    private void Awake() 
    {
        audioSource =  GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("CraftedScrap"))
        {
            ScrapMaterial sm = other.GetComponent<ScrapMaterial>();
            OnMoneyAdded?.Invoke(sm.moneyValue);
            Destroy(other.gameObject);
            audioSource.Play();
        }
    }
}
