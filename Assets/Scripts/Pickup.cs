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

    private InputAction _attackAction;

    public TempParent tempParent;
    Rigidbody rb;
    Vector3 objectPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tempParent = TempParent.Instance;

        _attackAction = InputSystem.actions.FindAction("Attack");
        _attackAction.performed += OnMouse;
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

        print("MOUSE DOWN");
        //pivkup
        print(tempParent != null);
        if (tempParent != null)
        {

            isHolding = true;
            rb.useGravity = false;
            rb.detectCollisions = true;

            this.transform.SetParent(tempParent.transform);
            print(this.transform);
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

        if (Input.GetMouseButtonDown(1))
        {
            //throw
        }
    }
}
