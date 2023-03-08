using UnityEngine;
using UnityEngine.InputSystem;

public class PickUp : MonoBehaviour
{
    [SerializeField] LayerMask whatToHit;

    private bool hasPickedUpObject;
    private Transform pickUpObjectTransform;
    [SerializeField] private float maxDistance = .6f;
    [SerializeField] private Vector3 size = new Vector3(.5f,2f,.5f);

    private UIFaceCamera lastUI;

    ScrapMaterial CurrentScapHeld;

    private PlayerControls controls;
    
    private void Awake() {
        controls = new PlayerControls();
        controls.Menu.Start.performed += ctx => PickUpObject(ctx);
    }

    private void Update() {
        RaycastHit hit;
        if(Physics.BoxCast(transform.position, size, transform.forward, out hit, transform.rotation, maxDistance, whatToHit)) 
        {
            lastUI = hit.transform.GetChild(hit.transform.childCount - 1).GetComponent<UIFaceCamera>();
            lastUI.show(true);
        }
        else if (lastUI != null)
        {
            lastUI.show(false);
        }
    }

    public void PickUpObject(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(hasPickedUpObject == false)
            {
                RaycastHit hit;
                if(Physics.BoxCast(transform.position, size, transform.forward, out hit, transform.rotation, maxDistance, whatToHit)) 
                {
                    CurrentScapHeld = hit.transform.GetComponent<ScrapMaterial>();
                    if (CurrentScapHeld.pickedUp == false)
                    {
                        lastUI.show(false);
                        hasPickedUpObject = true;
                        pickUpObjectTransform = hit.transform;

                        CurrentScapHeld.PickedUp();

                        hit.transform.GetComponent<Collider>().enabled = false;

                        Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                        rb.constraints = RigidbodyConstraints.FreezeAll;
                        rb.useGravity = false;


                        hit.transform.position = transform.position + (transform.forward * maxDistance) + (Vector3.up * .5f);
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

    public bool hasPickedup()
    {
        return hasPickedUpObject;
    }

    void OnDrawGizmos()
    {
        RaycastHit hit;
        if(Physics.BoxCast(transform.position, size, transform.forward, out hit, transform.rotation, maxDistance, whatToHit)) 
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            Gizmos.DrawWireCube(transform.position + (transform.forward * hit.distance), size);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
        }
    }
}
