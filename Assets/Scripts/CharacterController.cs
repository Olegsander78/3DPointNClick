using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    private float moveToUpdateRate = 0.1f;
    private float lastMoveToUpdate;
    private Transform moveTarget;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (moveTarget != null && Time.time - lastMoveToUpdate < moveToUpdateRate)
        {
            lastMoveToUpdate = Time.time;
            MoveToposition(moveTarget.position);
        }
    }
    public void LookTowards(Vector3 direction)
    {
        transform.rotation = Quaternion.LookRotation(direction);
    }
    public void MoveToTarget(Transform target)
    {
        moveTarget = target;
    }
    public void MoveToposition(Vector3 position)
    {
        agent.isStopped = false;
        agent.SetDestination(position);
    }
    public void StopMovement()
    {
        agent.isStopped = true;
        moveTarget = null;
    }
}
