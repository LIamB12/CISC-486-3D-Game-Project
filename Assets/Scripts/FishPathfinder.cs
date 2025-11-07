using Unity.Behavior;
using UnityEngine;

public class FishPathfinder : MonoBehaviour
{

    public Vector3 waypoint1;
    public Vector3 waypoint2;

    public Transform leakPos;
    private Vector3 goal;

    private BehaviorGraphAgent _agent;

    public GameObject yellowExclamationMark;
    public GameObject redExclamationMark;
    public GameObject orangeExclamationMark;
    public float patrolSpeed;
    public float escapeSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        goal = waypoint1;
        _agent = GetComponent<BehaviorGraphAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = patrolSpeed;
        Vector3 pos = this.transform.position;
        _agent.GetVariable("currentState", out BlackboardVariable<State> state);
        print(state.Value);
        float distance = Vector3.Distance(goal, pos);
        if (state.Value == State.Escaped)
        {
            redExclamationMark.SetActive(false);
            return;
        }
        if (state.Value == State.SeekLeak || state.Value == State.Escaping)
        {
            goal = leakPos.position;
            moveSpeed = escapeSpeed;
            if (distance < 1f)
            {
                yellowExclamationMark.SetActive(false);
                orangeExclamationMark.SetActive(true);
            } else
            {
                yellowExclamationMark.SetActive(true);
                orangeExclamationMark.SetActive(false);
            }
        } 
        else
        {
            if (distance < 2f)
            {
                if (goal == waypoint2)
                {
                    goal = waypoint1;
                }
                else
                {
                    goal = waypoint2;
                }
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, goal, moveSpeed * Time.deltaTime);
        transform.LookAt(goal);
    }
}
