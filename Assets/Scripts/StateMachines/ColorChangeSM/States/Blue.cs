using UnityEngine;
using UnityEngine.InputSystem;

public class Blue : BaseState
{

    private ColorSM _sm;

    public Blue(ColorSM stateMachine) : base("Blue", stateMachine)
    {
        _sm = (ColorSM)stateMachine;
    }
    public override void Enter()
    {
        base.Enter();
        _sm.rend.material = _sm.blueMaterial;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        // transition to Red State
        if (Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame)
        {
            stateMachine.changeState(_sm.redState);
        }

    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        //no physics logic needed
    }

}
