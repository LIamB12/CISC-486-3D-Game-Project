using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController _characterController;
    public float MovementSpeed = 10f, RotationSpeed = 5f, JumpForce = 10f, Gravity = -30f;

    private float _rotationY;
    private float _verticalVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector2 movementVector) {
        Vector3 move = transform.forward * movementVector.y + transform.right * movementVector.x;
        move = move * MovementSpeed * Time.deltaTime;
        _characterController.Move(move);

        _verticalVelocity = _verticalVelocity + Gravity * Time.deltaTime;
        _characterController.Move(new Vector3(0, _verticalVelocity, 0) * Time.deltaTime);
    }

    public void Rotate(Vector2 rotationVector) {
        _rotationY += rotationVector.x * RotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, _rotationY, 0);
    }

    public void Jump() {
        if (_characterController.isGrounded) {
            _verticalVelocity = JumpForce;
        }
    }
}
