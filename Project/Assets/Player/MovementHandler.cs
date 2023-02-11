using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class MovementHandler : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float groundDrag;
    [SerializeField] private float speed;

    private Rigidbody rb;
    private Vector2 movementInput = Vector2.zero;
   
    // gets the Character Controller and assigns it to the varible
    private void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.drag = groundDrag;
    }

    // Unity Event to get the input axis
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    // limiting players velocity
    private void Update() {
        Vector3 currentVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.y);
        if(currentVelocity.magnitude > speed)
        {
            Vector3 targetVelocity = currentVelocity.normalized * speed;
            rb.velocity = targetVelocity;
        }
    }

    // Update function to actually move the player
   private void FixedUpdate()
   {
        Vector3 moveVector = new Vector3(movementInput.x,0,movementInput.y);
        rb.AddForce(moveVector * speed, ForceMode.Force);
    }

}