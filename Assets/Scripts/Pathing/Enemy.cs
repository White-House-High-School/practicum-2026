using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform[] waypointList;

    //[SerializeField] public WaypointEnumerator wpE;

    private int waypointIndex = 0;
    public float movementSpeed = 2f;
    public float detectionThreshold = 0.02f;
    Transform currentPoint;
    private bool lastCheckpointReached = false;
    private EnemyHealth enemyHealth;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        // Instantiates a list of all of the waypoints.
        waypointList = WaypointEnumerator.points;
        // Instantiates an integer that is used to track how far the enemy has gotten.
        waypointIndex = 0;

        currentPoint = waypointList[waypointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (lastCheckpointReached || enemyHealth.isDead) 
        {
            return;
        }

        Vector3 dir = currentPoint.position - transform.position;
        float distance = Vector3.Distance(transform.position, currentPoint.transform.position);
        Debug.Log(distance);

        // If the enemy got to the waypoint
        if (distance <= detectionThreshold)
        {
            NextWaypoint();
        }

        Debug.Log("I am moving");
        transform.Translate(dir.normalized * movementSpeed * Time.deltaTime, Space.World);

    }

    void NextWaypoint()
    {
        // If there are more points, keep going
        if (waypointIndex < waypointList.Length - 1)
        {

            waypointIndex++;
            currentPoint = waypointList[waypointIndex];
            transform.LookAt(currentPoint);
            Debug.Log(waypointIndex);
            return;
        }
        Debug.Log("I have reached the final Waypoint.");
        lastCheckpointReached = true;
    }

}
