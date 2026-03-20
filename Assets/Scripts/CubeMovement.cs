using UnityEngine;

public class AutoMoveRight : MonoBehaviour
{
    // Determines the speed of the cube.
    [SerializeField] float speed = 5.0f;

    void Update()
    {
        // Moves the object to the right over time
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
