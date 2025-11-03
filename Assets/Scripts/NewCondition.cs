using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "New Condition", story: "[thrownBack]", category: "Variable Conditions", id: "16dcff137e9a575290e88712fd4154f4")]
public partial class NewCondition : Condition
{
    [SerializeReference] public BlackboardVariable<bool> ThrownBack;

    public override bool IsTrue()
    {
        return true;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
