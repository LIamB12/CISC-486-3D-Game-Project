using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem;

public class Pickup : MonoBehaviour
{

    bool isHolding = false;

    [SerializeField]
    float throwForce = 600f;
    [SerializeField]
    float maxDistance = 3f;
    float distance;

    private InputAction _attackAction, _dropAction, _throwAction;

    public TempParent tempParent;
    Rigidbody rb;
    Vector3 objectPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tempParent = TempParent.Instance;

        _attackAction = InputSystem.actions.FindAction("Attack");
        _dropAction = InputSystem.actions.FindAction("Drop");
        _throwAction = InputSystem.actions.FindAction("Interact");
        _attackAction.performed += OnMouse;
        _dropAction.performed += Drop;
        _throwAction.performed += Throw;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHolding)
        {
            Hold();
        }
    }

    private void OnMouse(InputAction.CallbackContext context)
    {

        rb = GetComponent<Rigidbody>();
        print("MOUSE DOWN");
        //pivkup
        print(tempParent != null);
        if (tempParent != null)
        {

            distance = Vector3.Distance(this.transform.position, tempParent.transform.position);
            print(distance);
            print(maxDistance);
            if(distance <= maxDistance)
            {
                isHolding = true;
                rb.useGravity = false;
                rb.detectCollisions = true;

                this.transform.SetParent(tempParent.transform);
                print(this.transform);
            }
        }
        else
        {
            Debug.Log("Temp parent not found");
        }
    }

    private void OnMouseUp()
    {

    }

    private void OnMouseExit()
    {

    }

    private void Hold()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void Throw(InputAction.CallbackContext context)
    {
        if(isHolding)
        {
            rb = GetComponent<Rigidbody>();
            Vector3 throwDirection = new Vector3(0, 15, 10);
            rb.AddForce((tempParent.transform.forward + throwDirection) * throwForce);
            isHolding = false;
            objectPos = this.transform.position;
            this.transform.position = objectPos;
            this.transform.SetParent(null);
            rb.useGravity = true;
        }
    }
 
    
    private void Drop(InputAction.CallbackContext context)
    {
        if(isHolding)
        {
            isHolding = false;
            objectPos = this.transform.position;
            this.transform.position = objectPos;
            this.transform.SetParent(null);
            rb.useGravity = true;
        }
    }
}
