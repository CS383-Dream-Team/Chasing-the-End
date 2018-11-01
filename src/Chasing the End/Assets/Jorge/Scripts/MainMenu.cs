using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


    private SceneLoader load = new SceneLoader();




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


    // this function is called to return to the main menu  
    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }



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
            load.SceneToLoad(againTry);
        }
    }

}
