using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFaceCamera : MonoBehaviour
{
    private void Start() {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.LookAt(Camera.main.transform.position,Vector3.up);
    }

    public void show(bool _bool)
    {
        gameObject.SetActive(_bool);
    }
}
