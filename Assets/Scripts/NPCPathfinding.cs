using UnityEngine;
using UnityEngine.AI;

public class NPCPathfinding : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetDestination();
    }

    void SetDestination()
    {
        if (waypoints.Length > 0)
        {
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
            navMeshAgent.isStopped = false; // Start or resume movement
        }
    }

    void Update()
    {
        if (navMeshAgent.isActiveAndEnabled && navMeshAgent.remainingDistance < 0.5f)
        {
            // Reached the current waypoint, move to the next one
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            SetDestination();
        }
    }

    // Call this method when the NPC should stop (e.g., on interaction)
    public void StopMovement()
    {
        navMeshAgent.isStopped = true; // Stop movement
    }

    // Call this method when the NPC should resume movement
    public void ResumeMovement()
    {
        navMeshAgent.isStopped = false; // Resume movement
        SetDestination(); // Set a new destination after resuming
    }
}
