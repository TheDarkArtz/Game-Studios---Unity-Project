using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class MovementHandler : MonoBehaviour
{
    private PlayerControls playerControls;
    private InputAction movementActon;

    [Header("Movement")]
    [SerializeField] private float groundDrag;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float moveSpeed;

    private Rigidbody rb;
    private Vector2 movementInput = Vector2.zero;
    private float lerp;

    private void Awake(){
        DontDestroyOnLoad(this);
        playerControls = new PlayerControls();
    }

    // gets the Character Controller and assigns it to the varible
    private void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.drag = groundDrag;
    }

    // Enabling and disabling controls if gameObject gets enabled or disabled (error handling)
    private void OnEnable() {
        movementActon = playerControls.Player.Movement;
        movementActon.Enable();
    }
    private void OnDisable() {
        movementActon.Disable();
    }

    // Unity Event to get the input axis
    private void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    // limiting players velocity
    private void Update() {
        Vector3 currentVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.y);
        if(currentVelocity.magnitude > moveSpeed)
        {
            Vector3 targetVelocity = currentVelocity.normalized * moveSpeed;
            rb.velocity = targetVelocity;
        }

        Vector2 movementInput = movementActon.ReadValue<Vector2>();
        if(movementInput != Vector2.zero)
        {
            Vector3 faceDirection = new Vector3(movementInput.x, 0f, movementInput.y);
            transform.forward = Vector3.Lerp(transform.forward, faceDirection, Time.deltaTime * turnSpeed);
        }
    }

    // Update function to actually move the player
   private void FixedUpdate()
   {
        Vector2 movementInput = movementActon.ReadValue<Vector2>();
        Vector3 moveVector = new Vector3(movementInput.x,0,movementInput.y);
        rb.AddForce(moveVector * moveSpeed, ForceMode.Force);
    }

}