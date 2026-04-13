
using UnityEngine;
using UnityEngine.InputSystem;
/* THIS IS A PLACEHOLDER CAMERA */
public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public Vector2 panLimit;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    void Update()
    {
        HandleMovement();
        HandleZoom();
    }

    void HandleMovement()
    {
        Vector3 pos = transform.position;

        Keyboard kb = Keyboard.current;
        Mouse mouse = Mouse.current;

        // WASD movement (Brackeys)
        if (kb.wKey.isPressed) pos.z += panSpeed * Time.deltaTime;
        if (kb.sKey.isPressed) pos.z -= panSpeed * Time.deltaTime;
        if (kb.dKey.isPressed) pos.x += panSpeed * Time.deltaTime;
        if (kb.aKey.isPressed) pos.x -= panSpeed * Time.deltaTime;

        // Edge scrolling (Brackeys)
        Vector2 mPos = mouse.position.ReadValue();

        if (mPos.y >= Screen.height - panBorderThickness) pos.z += panSpeed * Time.deltaTime;
        if (mPos.y <= panBorderThickness) pos.z -= panSpeed * Time.deltaTime;
        if (mPos.x >= Screen.width - panBorderThickness) pos.x += panSpeed * Time.deltaTime;
        if (mPos.x <= panBorderThickness) pos.x -= panSpeed * Time.deltaTime;

        // Clamp movement
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

        transform.position = pos;
    }
void HandleZoom()
    {
        float scroll = Mouse.current.scroll.ReadValue().y;

        Vector3 pos = transform.position;
        pos.y -= scroll * scrollSpeed * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
    
}
