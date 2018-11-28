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
    //Accessing the inventory made by Jorge
    public Inventory Inventory;



    //Trigger for loading scenes
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Find current working scene and sets the variable sceneName to the current scene name
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        //Checks if conditions to move to next level are met depending on current level
        if (((other.gameObject.CompareTag("Player")) && (Inventory.getNumberOfItems()==1) && (sceneName =="Level1")) || ((other.gameObject.CompareTag("Player")) && (Inventory.getNumberOfItems() ==2) && (sceneName == "level2")) ||
                ((other.gameObject.CompareTag("Player")) && (Inventory.getNumberOfItems() == 3) && (sceneName == "level3")) || ((other.gameObject.CompareTag("Player")) && (Inventory.getNumberOfItems() == 1) && (sceneName == "level4")))
        {
            SceneManager.LoadScene(index);
            SceneManager.LoadScene(levelName);
        }
    }
}
