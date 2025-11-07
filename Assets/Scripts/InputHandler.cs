using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{

    public PlayerController CharacterController;
    private InputAction _moveAction, _lookAction, _jumpAction, _attackAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _lookAction = InputSystem.actions.FindAction("Look");
        _jumpAction = InputSystem.actions.FindAction("Jump");
        _attackAction = InputSystem.actions.FindAction("Attack");

        _jumpAction.performed += onJumpPerformed;
        _attackAction.performed += onAttackPerformed;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementVector = _moveAction.ReadValue<Vector2>();
        CharacterController.Move(movementVector);

        Vector2 lookVector = _lookAction.ReadValue<Vector2>();
        CharacterController.Rotate(lookVector);


    }

    private void onJumpPerformed(InputAction.CallbackContext context) {
        CharacterController.Jump();
    }
    private void onAttackPerformed(InputAction.CallbackContext context) {
        CharacterController.Attack();
    }

}
