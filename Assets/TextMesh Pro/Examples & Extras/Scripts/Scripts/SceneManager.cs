using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class StartGame : MonoBehaviour
{
    public void SceneChange()
    {
        // Checks if the game is paused or not and if it is, it resets the timeScale and resets the isPaused boolean. (Ref. PauseGame.cs)
        if (PauseGame.isPaused)
            {
                // Continues our lifelong march toward death.
                Time.timeScale = 1.0f;
                // Resets the isPaused Boolean (Ref. PauseGame.cs)
                PauseGame.isPaused = !PauseGame.isPaused;
            }

        // If the current scene is not Main Menu, load the main menu.
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("MainMenu"))
        {
            SceneManager.LoadScene("MainMenu");
        }
        // If the current scene is the main menu load the gamescene.
        else
        {
            SceneManager.LoadScene("SampleScene");
        }
        
    }
}