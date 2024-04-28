using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : MonoBehaviour
{
    public Transform[] points; 
    public float speed = 1.0f; 
    public float waitTime = 3.0f; 
    private bool isPaused = false;
    public bool IsMoving { get; private set; }

    private int currentPointIndex = 0;

    private void Start()
    {
        StartCoroutine(MoveBetweenPoints());
    }
    public void PauseMovement()
    {
        isPaused = true;
        StopAllCoroutines();
    }

    public void ResumeMovement()
    {
        isPaused = false;
        StartCoroutine(MoveBetweenPoints());
    }
    private IEnumerator MoveBetweenPoints()
    {
        while (true)
        {
            if (isPaused)
            {
                yield return null;
                continue;
            }
            Transform targetPoint = points[currentPointIndex];
            while (Vector3.Distance(transform.position, targetPoint.position) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(waitTime);

            currentPointIndex = (currentPointIndex + 1) % points.Length;
        }
    }
}


