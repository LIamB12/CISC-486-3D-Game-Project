using UnityEngine;
using Unity.Behavior;
using UnityEngine.AI;
using System.Collections;

public class FishLauncher : MonoBehaviour
{
    private Rigidbody fish;
    private NavMeshAgent _navMeshAgent;
    private BehaviorGraphAgent fishBehavior;
    public string escapeVariableName = "inEscapingState";
    public Vector3 forceDirection = Vector3.up;
    public float forceMagnitude = 300f;
    public bool useGravity = true;
    public bool isKinematic = false;
    //private bool inEscapingState;
    private bool hasAppliedForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {

        if (fishBehavior == null)
            fishBehavior = GetComponent<BehaviorGraphAgent>();
        if (_navMeshAgent == null)
            _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void MakeRigidbody()
    {
        fish = GetComponent<Rigidbody>();
        if (fish == null)
        {
            fish = gameObject.AddComponent<Rigidbody>();
        }

        fish.useGravity = useGravity;
        fish.isKinematic = isKinematic;


    }


    void Update()
    {
        bool isEscaping = GetBoolFromGraph(escapeVariableName);

        if (isEscaping && !hasAppliedForce)
        {
            MakeRigidbody();
            _navMeshAgent.enabled = false;
            fish.AddForce(forceDirection.normalized * forceMagnitude, ForceMode.Impulse);
            StartCoroutine(MyCoroutine());

            hasAppliedForce = true;
            Debug.LogWarning($"Fish Launched");
        }

        if (!isEscaping && hasAppliedForce)
        {
            hasAppliedForce = false;
        }
    }
    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        gameObject.layer = LayerMask.NameToLayer("Default");

    }

    private bool GetBoolFromGraph(string variableName)
    {
        if (fishBehavior == null) return false;

        // Try to get the bool variable from the Blackboard
        if (fishBehavior.BlackboardReference.GetVariableValue(variableName, out bool value))
        {
            return value;
        }

        Debug.LogWarning($"Variable '{variableName}' not found or not a bool in Blackboard of {fishBehavior.gameObject.name}");
        return false;
    }

}