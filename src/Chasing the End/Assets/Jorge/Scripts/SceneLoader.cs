using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



/// <summary>
/// This class contains various was to load scenes ethier by name,
/// one higher than active, main menu or gameover
/// </summary>
public class SceneLoader : MonoBehaviour {


    /// <summary>
    /// Loads the Scene with the passed name from the inspecter or 
    /// from calling the class. 
    /// </summary>
    /// <param name="SceneName">Scene name to be loaded.</param>
    public void SceneToLoad(string SceneName)
    {
        SceneManager.LoadScene(SceneName );
    }


    /// <summary>
    /// Loads the Scene that is set to number 0 in the build settings. 
    /// Typically should be the Main Menu scene that should be loaded 
    /// with calling this fuction.
    /// </summary>
    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }

    
    /// <summary>
    ///This function calls the the GameOver Scene to be loaded
    /// </summary>
    public void Gameover()
    {
        SceneManager.LoadScene("GameOver");
    }


    // this function is called from the New game mainmenu canvas 
    /// <summary>
    ///This function gets the current active scene and changes to the next 
    ///scene in the array of selected scenes on the build settings.  
    /// </summary>
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
