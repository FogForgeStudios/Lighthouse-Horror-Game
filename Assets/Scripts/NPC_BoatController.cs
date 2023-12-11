using UnityEngine;

public class NPCBoatController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 30f;
    public Transform[] waypoints;
    private int currentWaypoint = 0;

    void Update()
    {
        if (waypoints.Length == 0) return;

        // Move towards the current waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);

        // Rotate towards the current waypoint
        Vector3 targetDirection = waypoints[currentWaypoint].position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Check if the boat reached the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
        {
            // Move to the next waypoint
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }
}
