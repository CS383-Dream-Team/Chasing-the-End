/*
 * Simple script to exit the credits scene and return
 * to the main menu. Scene name is passed through the
 * inspector on Unity.
 */
using UnityEngine;

public class Credits : MonoBehaviour 
{
    // Name of scene is passed on the inspector in unity.
    public void ChangeScene(string nameOfScene)
    {
        Application.LoadLevel(nameOfScene);
    }

}
