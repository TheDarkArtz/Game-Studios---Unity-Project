using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody))]
public class MovementHandler : MonoBehaviour
{
    /*
    private PlayerInput playerInput;
    private PlayerControls playerControls;
    */

    [Header("Movement")]
    [SerializeField] private float groundDrag;
    [SerializeField] private float turnSpeed;
    [Min(1)] [SerializeField] private float moveSpeed;

    [Header("Jumping")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCooldown;
    [Range(0,2)] [SerializeField] private float movementMultiplier;

    [Header("Ground")]
    [SerializeField] LayerMask isGround;

    private Vector2 movementInput = Vector2.zero;

    private bool grounded = false;
    private bool canJump = true;

    private CapsuleCollider capsuleCollider;
    private Rigidbody rb;
    
    private float currentMovmentMultiplier;
    private float lerp;

    private void Awake(){
        //playerControls = new PlayerControls();
        
        rb = gameObject.GetComponent<Rigidbody>();
        capsuleCollider = gameObject.GetComponent<CapsuleCollider>();

        /*
        playerInput = gameObject.GetComponent<PlayerInput>();
        playerInput.onActionTriggered += onActionTriggered;
        */
    }

    // gets the Character Controller and assigns it to the varible
    private void Start() {
        currentMovmentMultiplier = movementMultiplier;
        rb.drag = groundDrag;
    }

    // Enabling and disabling controls if gameObject gets enabled or disabled (error handling)
    private void OnEnable() {

    }
    private void OnDisable() {

    }

    /*
    private void onActionTriggered(InputAction.CallbackContext context)
    {
        switch (context.action.name)
        {
            case "Movement":
                OnMove(context);
                break;
            case "Jump":
                OnJump(context);
                break;
        }
    }
    */

    // Jump
    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            movementInput = context.ReadValue<Vector2>();
        }
    }
    // Jump
    public void OnJump(InputAction.CallbackContext context)
    {
        if (canJump && grounded && context.performed)
        {
            canJump = false;
            
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

            StartCoroutine(ResetJump());
        }
    }

    // limiting players velocity
    private void Update() {
        Vector3 currentVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.y);
        if(currentVelocity.magnitude > moveSpeed)
        {
            Vector3 targetVelocity = (currentVelocity.normalized * moveSpeed) * currentMovmentMultiplier;
            rb.velocity = targetVelocity;
        }

        // Rotate Character
        //Vector2 movementInput = movementActon.ReadValue<Vector2>();
        if(movementInput != Vector2.zero)
        {
            Vector3 faceDirection = new Vector3(movementInput.x, 0f, movementInput.y);
            transform.forward = Vector3.Lerp(transform.forward, faceDirection, turnSpeed * Time.deltaTime);
        }

        grounded = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.height * 0.5f + 0.2f, isGround);
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0.5f;
    }

    // Update function to actually move the player
   private void FixedUpdate()
   {
        //Vector2 movementInput = movementActon.ReadValue<Vector2>();
        Vector3 moveVector = new Vector3(movementInput.x,0,movementInput.y);
        
        currentMovmentMultiplier = 1;

        if(grounded == false)
            currentMovmentMultiplier = movementMultiplier;

        rb.AddForce((moveVector * moveSpeed) * currentMovmentMultiplier, ForceMode.Force);
    }


    private IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }
}