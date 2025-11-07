using UnityEngine;
using Unity.Behavior;
using UnityEngine.AI;
using System.Collections;
using Unity.VisualScripting;

public class FishDetector : MonoBehaviour
{

    public string throwableTag = "ThrowableObject";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(throwableTag))
        {
            Rigidbody fish_rb = other.attachedRigidbody;
            Transform fishTransform = other.transform;
            BehaviorGraphAgent agent = other.GetComponent<BehaviorGraphAgent>();
            NavMeshAgent navMeshAgent = other.GetComponent<NavMeshAgent>();

            Destroy(fish_rb);
            print("FISH LANDED");
            fishTransform.position = new Vector3(fishTransform.position.x, 3.58f, fishTransform.position.z);
            agent.SetVariableValue("thrownBack", true);
            navMeshAgent.enabled = true;
        }
    }
}
