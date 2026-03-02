using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed in the Unity Inspector

    // Update is called once per frame
    void Update()
    {
        // Move the object to the right in world space
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}