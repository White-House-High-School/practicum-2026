using UnityEngine;

public class QuitGame : MonoBehaviour
{
    
    public void ExitGame()
    {
        // Closes the application.
        Application.Quit();
        //Test case if you are in the Unity Editor.
        Debug.Log("Game is exiting");
        
        //exits the Play state if you are in the unity editor as opposed to a game itself.
         #if UNITY_EDITOR
             UnityEditor.EditorApplication.isPlaying = false;
         #endif
    }
}