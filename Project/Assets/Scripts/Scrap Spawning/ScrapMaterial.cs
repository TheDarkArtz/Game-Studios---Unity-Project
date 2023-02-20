using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapMaterial : MonoBehaviour
{
    public delegate void DestroyedHandler(string name);
    public static event DestroyedHandler OnScrapDestroyed;

    [SerializeField] private int value;

    private bool pickedUp = false;
    private float coundDown;
    private float timeCreated;
    
    void Start()
    {
        coundDown = Random.Range(5f,15f);
        timeCreated = Time.time;

        Invoke(nameof(DestroyGameObject), coundDown);
    }

    private void DestroyGameObject() {
        OnScrapDestroyed?.Invoke(gameObject.name);
        Destroy(gameObject);
    }

    //Public methods
    public void Pickedup()
    {
        CancelInvoke(nameof(DestroyGameObject));
        pickedUp = true;
    }
    private void Dropped()
    {
        pickedUp = false;
        Invoke(nameof(DestroyGameObject), coundDown);
    }
}
