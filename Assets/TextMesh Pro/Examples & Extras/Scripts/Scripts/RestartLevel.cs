    using UnityEngine;
    using UnityEngine.SceneManagement;
    using System.Collections;
    
    public class Restart : MonoBehaviour {
    
    	public void RestartGame() {
            // Checks if the game is paused or not and if it is, it resets the timeScale and resets the isPaused boolean. (Ref. PauseGame.cs)
            if (PauseGame.isPaused)
            {
                // Continues our lifelong march toward death.
                Time.timeScale = 1.0f;
                // Resets the isPaused Boolean (Ref. PauseGame.cs)
                PauseGame.isPaused = !PauseGame.isPaused;
                //isGameOver = !isGameOver;
            }
            // Loads the current scene the button was pressed on.
    		SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    	}
    
    }