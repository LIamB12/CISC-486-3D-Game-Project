using UnityEngine;
using System.Collections.Generic;
using Unity.Behavior;
using TMPro;

public class FishInTankCounter : MonoBehaviour
{
    private BehaviorGraphAgent fishBehavior;
    [SerializeField] public TextMeshProUGUI fishCounterTextOnScreen;
    [SerializeField] private string stateVariableName = "currentState";
    [SerializeField] private State patrolState = State.Patrol;
    [SerializeField] private State seekLeakState = State.SeekLeak;
    [SerializeField] private State escapingState = State.Escaping;
    int count;

    void Start()
    {
        UpdateCounter();
    }

    private void Update()
    {
        UpdateCounter();
    }


    public void UpdateCounter()
    {
        count = 0;
        var allAgents = GameObject.FindObjectsByType<BehaviorGraphAgent>(FindObjectsSortMode.None);
        foreach (var agent in allAgents)
        {
            var graphAgent = agent.GetComponent<BehaviorGraphAgent>();
            if (graphAgent == null)
                continue;
            if (graphAgent.GetVariable<State>(stateVariableName, out var currentStateVar))
            {
                if (currentStateVar.Value == patrolState || currentStateVar.Value == seekLeakState || currentStateVar.Value == escapingState)
                {
                    count++;
                }
            }
        }
        fishCounterTextOnScreen.text = $"Swimming Fish: {count}";

        if (count == 0)
        {
            fishCounterTextOnScreen.text = "All fish have escaped! You Lose!";
        }
    }

}
