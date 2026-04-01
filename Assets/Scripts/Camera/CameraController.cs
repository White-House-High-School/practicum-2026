// using UnityEngine;
// using UnityEngine.InputSystem;

// public class CameraControllerZoom : MonoBehaviour
// {
//     [SerializeField, Range(1f, 10f)] private float minZoom = 1f;
//     [SerializeField, Range(1f, 10f)] private float maxZoom = 5f;
//     [SerializeField, Range(1f, 10f)] private float zoomStrength = 5f;
  
//     private InputAction zoom;

//     private Camera _cam;
//     private float _targetZoom;
//     float zoomInput;

//     private void Start()
//     {
//         _cam = GetComponent<"Main Menu">();
//         _targetZoom = _cam.orthographicSize;
//         zoom = InputSystem.actions.FindAction("Zoom");
//         zoomInput = zoom.ReadValue<float>();
//     }


//     private void Update()
//     {
        
//         if (zoomInput != 0)
//         {
//             _targetZoom -= zoomInput = zoomStrength;
//             _targetZoom = Mathf.Clamp(_targetZoom, minZoom, maxZoom);
//         }
//         _cam.orthographicSize = _targetZoom;
//     }
// }
