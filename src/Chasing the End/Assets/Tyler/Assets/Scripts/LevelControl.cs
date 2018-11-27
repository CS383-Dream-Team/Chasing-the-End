using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Allows for different scenes to be loaded after a trigger.
/// In this case when the character with tag Player has specific items in their inventory
/// the specified scene will load in. -Tyler
/// </summary>
public class LevelControl : MonoBehaviour {

    public int index;
    //Must use scene name exactly to load correct scene
    public string levelName;

    //Trigger for loading scenes
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Player")))
        {
            SceneManager.LoadScene(index);
            SceneManager.LoadScene(levelName);
        }
    }
}
