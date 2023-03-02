using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapMaterial : MonoBehaviour
{
    public delegate void DestroyedHandler(string name);
    public static event DestroyedHandler OnScrapDestroyed;

    public int moneyValue;

    public bool pickedUp { get; private set; } = false;
    private float coundDown;
    private float timeCreated;
    
    void Start()
    {
        coundDown = Random.Range(20f,30f);
        timeCreated = Time.time;

        Invoke(nameof(DestroyGameObject), coundDown);
    }

    private void DestroyGameObject() {
        Destroy(gameObject);
    }
    
    private void OnDestroy() {
        OnScrapDestroyed?.Invoke(gameObject.name);
    }

    //Public methods
    public void PickedUp()
    {
        CancelInvoke(nameof(DestroyGameObject));
        pickedUp = true;
    }
    public void Dropped()
    {
        pickedUp = false;
        Invoke(nameof(DestroyGameObject), coundDown);
    }
    public void DisableDestroy()
    {
        CancelInvoke(nameof(DestroyGameObject));
    }
}
