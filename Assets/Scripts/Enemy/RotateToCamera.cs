using UnityEngine;

public class RotateToCamera: MonoBehaviour
{
    // Reference to the main camera, automatically found if not assigned in the Inspector
    public Camera mainCamera;

    void Start()
    {
        // mainCamera = Camera.main;
    }

    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        if (mainCamera != null)
        {
            // Make the canvas look at the camera position
            // The canvas's local "forward" (usually Z-axis) will point towards the camera's position
            transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.back, mainCamera.transform.rotation * Vector3.up);
        }
    }
}
