using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerAbility;

public class BugSprayAbility : PlayerAbility
{
    private float coolDown; // Implement coolDown later
    private float timeSinceLastUse; // Implement timeSinceLastUse with coolDown
    public GameObject sphereOfInfluence; // The sphere that will damage enemies. Connect a prefab of a sphere in this section.
    public GameObject plane; // The stand-in for the ground. When merging, make this object be our ground.
    public Camera cam; // The world camera. Set it to the main camera

    private InputAction leftClick; // Unity 6 input system. I have this set to the left click on the mouse

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    override public void Start()
    {
        cam = Camera.main; // Instantiate the camera as the main camera
        coolDown = 60.0f; // Instantiating the coolDown variable. Cooldown timer is in seconds.
        timeSinceLastUse = 60.0f; // Instantiating the timeSinceLastUse variable. Variable is in seconds.
        leftClick = InputSystem.actions.FindAction("Player Ability"); // Instantiating the left click. My input map is titled "Player Ability" in the input system.
        
    }

    // Update is called once per frame
    override public void Update()
    {
        // When I hit left click, record the location of the mouse when I clicked, then send it to the UseAbility method.
        if (leftClick.WasPressedThisFrame()) 
        {
            // Record mouseX and mouseY as floats so that I have the coordinates of the click, with respect to the screen.
            float mouseX = Mouse.current.position.x.ReadValue(); float mouseY = Mouse.current.position.y.ReadValue();  

            Vector2 mousePos = new Vector2(mouseX, mouseY); // Store both of those in a Vector2 so that I can manage them more efficiently.
            UseAbility(mousePos); // Send that Vector2 to UseAbility()
        }
    }

    public override void UseAbility(Vector2 mP) // Input the mouse position
    {
        Collider planeCollider = plane.GetComponent<Collider>(); // Define the ground's Collider.
        
        Ray ray = cam.ScreenPointToRay((mP)); // Create a ray where I clicked earlier
        
        RaycastHit hit; // Creates a RaycastHit
        Physics.Raycast(ray, out hit); // Shoot the Ray from earlier

        if (hit.collider == planeCollider) // If the ray's collider contacts the plane's collider, create a sphere where the ray hit.
        {
            Instantiate(sphereOfInfluence, hit.point, Quaternion.identity);
        }
        
    } 
}
