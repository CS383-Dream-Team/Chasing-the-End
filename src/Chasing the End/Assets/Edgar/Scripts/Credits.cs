/*
 * Simple script to exit the credits scene and return
 * to the main menu onClick().
 */
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour 
{
    // Name of the scene is passed in this function.
    public void ChangeScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
