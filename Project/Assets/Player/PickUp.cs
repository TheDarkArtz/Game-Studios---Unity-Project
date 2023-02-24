using UnityEngine;
using UnityEngine.InputSystem;

public class PickUp : MonoBehaviour
{
    [SerializeField] LayerMask whatToHit;

    private bool hasPickedUpObject;
    private Transform pickUpObjectTransform;
    private float maxDistance = .5f;

    ScrapMaterial CurrentScapHeld;

    private PlayerControls controls;

    private void Awake() {
        controls = new PlayerControls();
        controls.Menu.Start.performed += ctx => PickUpObject(ctx);
    }

    public void PickUpObject(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(hasPickedUpObject == false)
            {
                RaycastHit hit;
                if(Physics.BoxCast(transform.position, transform.lossyScale / 2, transform.forward, out hit, transform.rotation, maxDistance, whatToHit)) 
                {
                    CurrentScapHeld = hit.transform.GetComponent<ScrapMaterial>();
                    if (CurrentScapHeld.pickedUp == false)
                    {
                        hasPickedUpObject = true;
                        pickUpObjectTransform = hit.transform;

                        CurrentScapHeld.PickedUp();

                        hit.transform.GetComponent<Collider>().enabled = false;

                        Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                        rb.constraints = RigidbodyConstraints.FreezeAll;
                        rb.useGravity = false;


                        hit.transform.position = transform.position + (transform.forward * maxDistance);
                        hit.transform.SetParent(transform);
                    }
                }
            }
            else
            {
                CurrentScapHeld.Dropped();
                pickUpObjectTransform.SetParent(null);

                pickUpObjectTransform.transform.GetComponent<Collider>().enabled = true;

                Rigidbody rb = pickUpObjectTransform.transform.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.None;
                rb.useGravity = true;

                hasPickedUpObject = false;
                pickUpObjectTransform = null;
                CurrentScapHeld = null;
            }
        }
    }

    void OnDrawGizmos()
    {
        RaycastHit hit;
        if(Physics.BoxCast(transform.position, transform.lossyScale / 2, transform.forward, out hit, transform.rotation, maxDistance, whatToHit)) 
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            Gizmos.DrawWireCube(transform.position + (transform.forward * hit.distance), transform.lossyScale);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
        }
    }
}
