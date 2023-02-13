using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;

    private void Update()
    {
        Vector3 targetPosition = target.position;
        Vector3 currentPosition = transform.position;

        Vector3 CurrentToTarget = targetPosition - currentPosition;

        transform.Translate(CurrentToTarget.normalized * speed * Time.deltaTime);
    }
}
