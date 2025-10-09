using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Range Check", story: "Check [Target] in Range [Detector]", category: "Conditions", id: "21bec9d5038e0e3785fe0b8c9e850e90")]
public partial class RangeCheckCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<RangeDetector> Detector;

    public override bool IsTrue()
    {
        return Detector.Value.FindTarget() != null ? true : false;
    }
}
