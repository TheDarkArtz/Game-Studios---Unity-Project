using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody))]
public class MovementHandler : MonoBehaviour
{

    [Header("Animations")]
    [SerializeField] private Animator[] _anim;
    private int currentState;

    private readonly int Idle = Animator.StringToHash("idle2");
    private readonly int Walk = Animator.StringToHash("walk1");
    private readonly int Holding = Animator.StringToHash("holding");
    private readonly int Carry = Animator.StringToHash("carrying ");
    private readonly int Hop = Animator.StringToHash("hop");

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

    private PickUp pickupScript;

    private Vector2 movementInput = Vector2.zero;

    private bool grounded = false;
    private bool canJump = true;

    private CapsuleCollider capsuleCollider;
    private Rigidbody rb;
    
    private float currentMovmentMultiplier;
    private float lerp;

    [SerializeField] private GameObject[] characters;
    public int selectedCharacter = 0;
    public Transform spawnPoint;
    public int id = 0;

    private void Awake(){
        //playerControls = new PlayerControls();
        
        rb = gameObject.GetComponent<Rigidbody>();
        capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
        pickupScript = gameObject.GetComponent<PickUp>();

        /*
        playerInput = gameObject.GetComponent<PlayerInput>();
        playerInput.onActionTriggered += onActionTriggered;
        */
    }

    // gets the Character Controller and assigns it to the varible
    private void Start() {
        currentMovmentMultiplier = movementMultiplier;
        rb.drag = groundDrag;
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;
        characters[selectedCharacter].SetActive(true);
    }

    // Enabling and disabling controls if gameObject gets enabled or disabled (error handling)
    private void OnEnable() {

    }
    private void OnDisable() {

    }

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

        int state = GetState();
        if (state != currentState)
        {
            _anim[selectedCharacter].CrossFade(state, .2f, 0);
            currentState = state;
        };
    }

    private int GetState()
    {
        var walking = Walk;
        var idle = Idle;

        if (pickupScript.hasPickedup())
        {
            walking = Carry;
            idle = Holding;
        }

        if (canJump == false)
        {
            return Hop;
        }

        return movementInput == Vector2.zero ? idle : walking;
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