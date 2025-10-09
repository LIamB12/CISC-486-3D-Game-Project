using UnityEngine;

public class RangeDetector : MonoBehaviour
{

    public GameObject leak;
    public float detectionRange = 0.5f;
    public bool inRange = false;

    // Update is called once per frame
    public GameObject FindTarget()
    {

        float distanceToTarget = Vector3.Distance(transform.position, leak.transform.position);

        if (distanceToTarget <= detectionRange)
        {
            return leak;
        }
        else
        {
            return null;
        }
    }
}
