using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabObject : MonoBehaviour
  

{

    bool PickedUpObject;
    GameObject Prop;
    Transform worldObjectHolder;

    Keyboard keyboard;

    RaycastHit m_Hit;
    void Start()

    {
        worldObjectHolder = GameObject.FindGameObjectWithTag("Grabbable").transform;
        keyboard = Keyboard.current;
    }

    private void Update()
    {
        if (keyboard != null)
        {
            if (keyboard.zKey.isPressed)
            {
                Debug.Log("Grab inniatied");
            }
    }




    void grabObject(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RaycastHit hit;
            Vector3 direction = transform.forward;
            Physics.BoxCast(transform.position + (direction * 10), new Vector3(0, 0, 5), direction * 5, out hit);
                {

                }
        }
    }




    /* void Update()
     {
         if (grabprop == true)
         {
             if (Input.GetKeyDown("z"))
             {
                 GrabbableProp.GetComponent<Rigidbody>().isKinematic = true;
                 GrabbableProp.transform.position = HAND.transform.position;
                 GrabbableProp.transform.parent = HAND.transform; 
             }
         }
         if (Input.GetButtonDown("c") && playergrabprop == true)
         {
             GrabbableProp.GetComponent<Rigidbody>().isKinematic = false;

             GrabbableProp.transform.parent = null;
         }
     } */


    /*private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Grabbable")
        {
            grabprop = true;
            GrabbableProp = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        grabprop = false;
    } */

}

}
