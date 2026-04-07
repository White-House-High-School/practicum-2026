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
    private EnemyHealth enemyHealth; // Keeps track of each ant's health.
    float turningSpeed; // How fast the ant turns
    public float rotationSpeed = 90f;
    private float angleOfTolerance = 1f;

    private bool shouldTurn;

    void Start()
    {
        turningSpeed = 50f * Time.deltaTime;

        enemyHealth = GetComponent<EnemyHealth>(); // Instantiates the ant's health
        waypointList = WaypointEnumerator.points; // Instantiates a list of all of the waypoints.
        waypointIndex = 0; // Instantiates an integer that is used to track how far the enemy has gotten.

        currentPoint = waypointList[waypointIndex]; // We heading to this point rn frfr

        // Starting the ant pointing at the second waypoint, not the first. Otherwise, the ant starts looking the wrong way and has to turn and it looks janky and wrong. 
        Vector3 directionToTarget = waypointList[0].position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        transform.rotation = targetRotation;
    }

    // Update is called once per frame
    void Update()
    { 
       Move(); // Every frame we Shmoovin'
    }


    void Move() // Moves the enemy :3
    {

        if (enemyHealth.getIsDead() || travelledAllWaypoints()) // If we are dead, or we are at the last waypoint, don't move            
            return;

        shouldTurn = atCurrentWaypoint() && !facingNextWaypoint();

        if (shouldTurn) // If we should turn, Turn, but don't move
            Turn();

        else if (atCurrentWaypoint()) // If we get to the waypoint, move to the next waypoint
            NextWaypoint();
        
        else // If none of those conditions are true, move.
        {
            Vector3 dir = currentPoint.position - transform.position; // What direction are we Shmoovin' in?
            transform.Translate(dir.normalized * movementSpeed * Time.deltaTime, Space.World); // If business as usual, we Shmoovin'  
        }
 
    }

    void NextWaypoint() // Changes the ant's focus to the next wp
    {    
        waypointIndex++; // Cycle the WaypointIndex up
        int wpl = waypointList.Length - 1;
        
        currentPoint = waypointList[waypointIndex]; // Set our sights onto that new waypoint
    }

    bool travelledAllWaypoints() // Checks to see if we have gotten to the last waypoint
    {
        return waypointIndex >= waypointList.Length - 1; 
    }

    bool atCurrentWaypoint() // Checks if we have gotten to our current, targeted waypoint
    {
        float distance = Vector3.Distance(transform.position, currentPoint.transform.position); // How far away from the targeted waypoint are we?
        return distance <= detectionThreshold; // ARE WE THERE YET????
    }

    bool facingNextWaypoint() // Are we facing the NEXT waypoint?
    {
        Transform nextWaypoint = waypointList[waypointIndex + 1]; // Identifies the next waypoint.
        Vector3 directionToTarget = nextWaypoint.position - transform.position; // Grabs the direction vector that we need to turn.
        
        float antToWpAngle = Vector3.Angle(transform.forward, directionToTarget); // What is the angle between the next waypoint and the ant's forward?

        return antToWpAngle <= angleOfTolerance; // Is the ant looking at the next waypoint? 
    }

    void Turn() // Turn to the next waypoint
    {   
        Transform nextWaypoint = waypointList[waypointIndex + 1]; // Identifies the next waypoint
        Vector3 directionToTarget = (nextWaypoint.position - transform.position).normalized; // Grabs the direction vector that we need to turn

        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget); 

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // Turn toward the point.
    }

}
