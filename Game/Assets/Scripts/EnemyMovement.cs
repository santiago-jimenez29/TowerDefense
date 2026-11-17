
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 3f;

    private int currentWaypoint = 0;

    
    public Vector3 CurrentVelocity
    {
        get
        {
            if (waypoints == null ||
                currentWaypoint >= waypoints.Length ||
                waypoints[currentWaypoint] == null)
                return Vector3.zero;

            Vector3 direction =
                waypoints[currentWaypoint].position
                - transform.position;

            if (direction.sqrMagnitude < 0.0001f)
                return Vector3.zero;

            return direction.normalized * speed;
        }
    }

    void Update()
    {
        if (GameManager.IsGameOver)
            return;

        if (waypoints.Length == 0)
            return;

        // Move toward the current waypoint
        Transform target = waypoints[currentWaypoint];

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        // Check if we reached the current waypoint
        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
            Debug.Log("Reached waypoint " + (currentWaypoint + 1));

            currentWaypoint++;

            // Game Over only after the LAST waypoint
            if (currentWaypoint >= waypoints.Length)
            {
                GameManager manager =
                    FindFirstObjectByType<GameManager>();

                if (manager != null)
                {
                    manager.EndGame();
                }

                enabled = false;
            }
        }
    }
}
