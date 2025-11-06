using UnityEngine;

public class FishPathfinder : MonoBehaviour
{

    public Vector3 waypoint1;
    public Vector3 waypoint2;
    public float fishSpeed;
    private Vector3 goal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;
        float distance = Vector3.Distance(goal, pos);
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
        this.transform.Translate(goal.normalized * Time.deltaTime * fishSpeed);
    }
}
