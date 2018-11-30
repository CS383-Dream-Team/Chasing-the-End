using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Script used for the main Menu of the Game
/// </summary>
public class MainMenu : SceneLoader {

    // this function is called from the New game mainmenu canvas 
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // this function is called form the quit buttom in the main menu canvas 
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// called to check what was the last level and to load it
    /// </summary>
    public void retry()
    {
        string againTry;
        againTry = Persistent.GetInstance().GetRetryPoint();
        if (againTry == null)
        {
            Debug.Log("Error loading scene has no name");
        }
        else
        {
             SceneToLoad(againTry);
        }
    }

}
