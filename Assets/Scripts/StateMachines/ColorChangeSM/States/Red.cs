using UnityEngine;
using UnityEngine.InputSystem;

public class Red : BaseState
{

    private ColorSM _sm;

    public Red(ColorSM stateMachine) : base("Red", stateMachine)
    {
        _sm = (ColorSM)stateMachine;
    }
    public override void Enter()
    {
        base.Enter();
        _sm.rend.material = _sm.redMaterial;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        // transition to Blue State
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            stateMachine.changeState(((ColorSM)stateMachine).blueState);
        }

    }
    
    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        //no physics logic needed
    }

}
