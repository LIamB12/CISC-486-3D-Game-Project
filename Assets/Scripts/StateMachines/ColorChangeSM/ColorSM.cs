using UnityEngine;

public class ColorSM : StateMachine
{
    [HideInInspector]
    public Blue blueState;
    [HideInInspector]
    public Red redState;
    [HideInInspector]
    public Renderer rend;

    public Material redMaterial;
    public Material blueMaterial;

    private void Awake()
    {
        blueState = new Blue(this);
        redState = new Red(this);
        rend = GetComponent<Renderer>();
    }

    protected override BaseState GetInitialState()
    {
        return redState;
    }
}
