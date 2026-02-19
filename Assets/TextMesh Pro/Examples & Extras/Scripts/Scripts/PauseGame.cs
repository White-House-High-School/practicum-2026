using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    // Keeps track of if the game is paused.
    public static bool isPaused = false;
    // Keeps track of the pause button. (How?)
    private InputAction pauseButton;
    // Refers to the Pause Screen in the Hierarchy. (make clearer)
    [SerializeField] private GameObject PauseScreen;

    public void Start()
    {
        // Grabs the input from the pause button. (good)
        pauseButton = InputSystem.actions.FindAction("Pause");
    }
    // Update is called once per frame
    void Update()
    {
        //If they press pause button, toggle Pause. (maybe "pause the game")
        if (pauseButton.WasPressedThisFrame())
        {
            TogglePause();
        }
    }

    // Handles Pausing the game.
    public void TogglePause()
    {
        // Switches the button, I.E. if it was unpaused, it is now paused. 
        // Toggles the pause state. If it was unpaused, it is now paused.
        isPaused = !isPaused;

        if (isPaused)
        {
            Debug.Log("Game is paused");
            // Makes the Pause Screen appear on screen.
            PauseScreen.SetActive(true);

            // Stops time from moving.
            // Halts the everpresent, oppressive, looming presence of time 
            Time.timeScale = 0.0f;
        }
        else
        {
            Debug.Log("Game is unpaused");
            // Removes Pause Screen from the screen.
            PauseScreen.SetActive(false);
            //Makes time move again.
            // Continues our lifelong march toward death.
            Time.timeScale = 1.0f;
        }
    }
}