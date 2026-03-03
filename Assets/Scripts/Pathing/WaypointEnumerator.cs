using UnityEngine;

public class WaypointEnumerator : MonoBehaviour
{
    public static Transform[] points; // Creates a list of all of the points. Each point is nothing more than a Vector3 with in-game coordinates (X, Y, Z).

    void Awake() // As soon as the game even starts
    {
        points = new Transform[transform.childCount];  

        for (int i = 0; i < points.Length; i++) // For as many points as there are, add each point into a list of points.
        {
            points[i] = transform.GetChild(i); // Pretty self-explanatory.
        }
    }
}
