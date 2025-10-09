using UnityEngine;
using System.Collections;


public class LeakSpawner : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(2.17f, 1.8f, 14.89f);
    public Vector3 targetPosition2 = new Vector3(0f, 1.8f, 14.89f);
    public Vector3 targetPosition3 = new Vector3(4f, 1.8f, 14.89f);
    public float delayTime = 10f;

    void Start()
    {
        StartCoroutine(MoveAfterDelay());
    }

    IEnumerator MoveAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);

        transform.position = targetPosition;

        yield return new WaitForSeconds(delayTime);
        transform.position = targetPosition2;

        yield return new WaitForSeconds(delayTime);
        transform.position = targetPosition3;

        yield return new WaitForSeconds(delayTime);
        transform.position = targetPosition2;

        yield return new WaitForSeconds(delayTime);
        transform.position = targetPosition;

        yield return new WaitForSeconds(delayTime);
        transform.position = targetPosition3;
    }
}
