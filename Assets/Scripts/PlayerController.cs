using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController _characterController;
    public float MovementSpeed = 10f, RotationSpeed = 5f, JumpForce = 10f, Gravity = -30f;

    private float _rotationY;
    private float _verticalVelocity;

    private Animator _animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

    }

    void Update()
    {
        AnimatorStateInfo state = _animator.GetCurrentAnimatorStateInfo(0);
        if (state.IsName("Swat") && state.normalizedTime >= 0.4f) {
            _animator.SetBool("isAttacking", false);
        }
    }

    public void Move(Vector2 movementVector) {
        Vector3 move = transform.forward * movementVector.y + transform.right * movementVector.x;
        move = move * MovementSpeed * Time.deltaTime;
        _characterController.Move(move);

        _animator.SetFloat("ForwardSpeed", movementVector.y);
        _animator.SetFloat("HorizontalSpeed", movementVector.x);

        _verticalVelocity = _verticalVelocity + Gravity * Time.deltaTime;
        _characterController.Move(new Vector3(0, _verticalVelocity, 0) * Time.deltaTime);

        if (_characterController.isGrounded && _animator.GetBool("isJumping"))
        {
            _animator.SetBool("isJumping", false);
        }
    }

    public void Rotate(Vector2 rotationVector) {
        _rotationY += rotationVector.x * RotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, _rotationY, 0);
    }

    public void Jump()
    {
        if (_characterController.isGrounded)
        {
            _verticalVelocity = JumpForce;
            _animator.SetBool("isJumping", true);
        }
    }
    
    public void Attack()
    {
        if (_characterController.isGrounded)
        {
            _animator.SetBool("isAttacking", true);
            
        }
    }
}
