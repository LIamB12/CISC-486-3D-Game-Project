using UnityEngine;
using Unity.Behavior;
using UnityEngine.AI;
using System.Collections;
using Unity.VisualScripting;

public class FishDetector : MonoBehaviour
{

    public bool thrownBack;
    public GameObject fishObj;
    public NavMeshAgent _navMeshAgent;

    public BehaviorGraphAgent behaviorGraphAgent;

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
            Rigidbody fish_rb = fishObj.GetComponent<Rigidbody>();
            Destroy(fish_rb);
            print("FISH LANDED");
            fishObj.transform.position = new Vector3(fishObj.transform.position.x, 3.58f, fishObj.transform.position.z);
            behaviorGraphAgent.SetVariableValue("thrownBack", true);
            _navMeshAgent.enabled = true;
        }
    }
}
