using Unity.VisualScripting;
using UnityEngine;

public class LeakRepairRange : MonoBehaviour
{

    public GameObject leak;
    public float detectionRange = 3f;
    public bool inRange = false;

    void Update()
    {
        float distanceToLeak = Vector3.Distance(transform.position, leak.transform.position);

        if (distanceToLeak <= detectionRange)
        {
            leak.transform.position = new Vector3(10f, 100f, 10f);
        }
    }
}
