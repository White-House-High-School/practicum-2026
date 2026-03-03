using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform[] waypointList; // The one and only waypoint list
    private int waypointIndex = 0; // Keeps track of each ant's progress
    public float movementSpeed = 2f; // How fast are we shmoovin?
    public float detectionThreshold = 0.02f; // Allows for a little bit of error when walking to points. NOTE: YOU WILL PROBABLY NEED TO MAKE THIS SMALLER.
    public float timer; // I think that this isn't necessary, but I feel like if I touch it, everything might come crashing down, so I am going to leave it out of fear for what might happen if I don't trust my better judgement.
    public string type; // Same thing as timer. May God have mercy on our souls, should some poor sap touch this variable. 
    Transform currentPoint; // This is just the current waypoint that we are going toward for shorthand.
    private bool lastCheckpointReached = false; // Are we at the last waypoint?
    private EnemyHealth enemyHealth; // Keeps track of each ant's health.

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>(); // Instantiates the ant's health
        waypointList = WaypointEnumerator.points; // Instantiates a list of all of the waypoints.
        waypointIndex = 0;// Instantiates an integer that is used to track how far the enemy has gotten.

        currentPoint = waypointList[waypointIndex]; // We at this point rn frfr
    }

    // Update is called once per frame
    void Update()
    {
        Move(); // Every frame we Shmoovin'
    }


    void Move() // Moves the enemy :3
    {
        if (lastCheckpointReached || enemyHealth.isDead) // If we are at the last point or we are dead, don't move. Eventually make this get checked in Update so we don't have to ender this func.
        {
            return;
        }

        Vector3 dir = currentPoint.position - transform.position; // What direction are we Shmoovin' in?
        float distance = Vector3.Distance(transform.position, currentPoint.transform.position); // How far do we have to Shmoov?

        if (distance <= detectionThreshold) // ARE WE THERE YET????
        {
            NextWaypoint(); // If so, we need to shmoov to the next wp.
        }

        transform.Translate(dir.normalized * movementSpeed * Time.deltaTime, Space.World); // If business as usual, we Shmoovin'

    }

    void NextWaypoint() // Changes the ant's focus to the next wp
    {
        // If there are more points, keep going
        if (waypointIndex < waypointList.Length - 1)
        {

            waypointIndex++;
            currentPoint = waypointList[waypointIndex];
            transform.LookAt(currentPoint); // ADD LERPING LATER
            return;
        }
        
        lastCheckpointReached = true;
    }

}
