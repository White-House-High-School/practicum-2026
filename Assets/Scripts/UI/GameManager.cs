using UnityEngine;
using UnityEngine.SceneManagement; 


using UnityEngine.InputSystem;




public class GameManager : MonoBehaviour
{
    // Keeps track of if the game is paused.
    public static bool isPaused = false;
    // Keeps track of the pause button.
    private InputAction pauseButton;
    // Refers to the Pause Screen in the Hierarchy.
    [SerializeField] private GameObject PauseScreen;
    public static bool isGameOver;
    [SerializeField] private GameObject GameOverScreen;
    private GameObject HealthBar;
    [SerializeField] private GameObject HealthBarPrefab;
    [SerializeField] private GameObject Basket;
    public void Start()
    {
        HealthBar = GameObject.Find("CurrentHealth");
        // Grabs the input from the pause button. (good)
        pauseButton = InputSystem.actions.FindAction("Pause");
        //picnicBasketHealth = basket.GetHealth();
    }
    // Update is called once per frame
    void Update()
    {
        //If they press pause button, toggle Pause. (maybe "pause the game")
        if (pauseButton.WasPressedThisFrame() && isGameOver == false)
        {
            TogglePause();
        }
        if (!PauseScreen.activeInHierarchy)
        {
            isPaused = false;
            isGameOver = false;
            Time.timeScale = 1.0f;
        }
        if (HealthBar == null)
        {
            if (!isGameOver)
            {
                GameOver();
            }
        }

        //Debug.Log(Time.timeScale);
    }

    public void SceneChange()
    {
            // Checks if the game is paused or not and if it is, it resets the timeScale and resets the isPaused boolean.
            Time.timeScale = 1.0f;
            isPaused = false;
            isGameOver = false;
            // If the current scene is not Main Menu, load the main menu.
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("MainMenu"))
            {
                SceneManager.LoadScene("MainMenu");
                
            }
            // If the current scene is the main menu load the gamescene.
            else
            {
                SceneManager.LoadScene("MainScene");
            }
            
        
    }
    public void RestartGame() 
    {
            // Loads the current scene the button was pressed on.
            Instantiate(HealthBarPrefab, Basket.transform.position, Quaternion.identity);

            var baseHealth = Basket.GetComponent<BaseHealth>();
            baseHealth.SetHealth(baseHealth.maxHealth);
            Debug.Log("Max Health " + baseHealth.maxHealth);
            Debug.Log("Current Health " + baseHealth.currentHealth);

    		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1.0f;
            isPaused = false;
            isGameOver = false;

            
    }

    public void ExitGame()
    {
        // Closes the application.
        Application.Quit();
        //Test case if you are in the Unity Editor.
        Debug.Log("Game is exiting");
        
        //exits the Play state if you are in the unity editor as opposed to a game itself.
        if (Application.isEditor)
        {
             UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    // Handles Pausing the game.
    public void TogglePause()
    {
        // Toggles the pause state. If it was unpaused, it is now paused.
        isPaused = !isPaused;

        if (isPaused)
        {
            Debug.Log("Game is paused");
            if(!PauseScreen.activeInHierarchy)
            {
            // Makes the Pause Screen appear on screen.
            PauseScreen.SetActive(true);
            }
            // Halts the everpresent, oppressive, looming presence of time 
            Time.timeScale = 0.0f;
        }
        else
        {
            Debug.Log("Game is unpaused");
            // Removes Pause Screen from the screen.
            if(PauseScreen.activeInHierarchy)
            {
                PauseScreen.SetActive(false);
            }
            // Continues our lifelong march toward death.
            Time.timeScale = 1.0f;
        }
    }
    
    public void GameOver()
    {
        isGameOver = !isGameOver;
        {
            if (isGameOver)
            {
//                Debug.Log("Game Over!");
                Time.timeScale = 0.0f;
                if (!GameOverScreen.activeInHierarchy)
                {
                    GameOverScreen.SetActive(true);
                }
            }
            else
            {
                Time.timeScale = 1.0f;
                if (GameOverScreen.activeInHierarchy)
                {
                    GameOverScreen.SetActive(false);
                }
            }
        }
    }
    public bool GetIsGameOver()
    {
        return isGameOver;
    }
    
}