using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Persistent : MonoBehaviour {

    static protected int Lives = 3;
    static protected int Score = 0;
    static protected string GameOver = "GameOVer";
    static protected Scene currentScene;
    static protected string retryPoint;

    static Persistent FirstInstance;    //Static first instance is the only instance in the game 
                                        // its only created once in anyothers will be destroyed

	// Use this for initialization
	void Start () {

        retryPoint = currentScene.name;
        currentScene = SceneManager.GetActiveScene();



        Debug.Log(FirstInstance);

        if (FirstInstance != null)
        {
            Debug.Log("its getting destroy");
            Destroy(this.gameObject);
            return; 
        }
        Debug.Log(FirstInstance);
        FirstInstance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }


    //  
    /// <summary>
    /// this is to get and instance of the this class but cannot be changed with it 
    ///  example Persistent class to get the score..it must be used it the
    ///   Persistent.GetInstance().GetScore() to get the score from the class
    /// </summary>
    public static Persistent GetInstance()
    {
        return FirstInstance;
    }

    /*
     * Will remove this function to the the loader class scene..
     * this fuunction just calls to load the main menu scene
     */
    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }

    /* this gets called when the objects is about to be destroy i could save the player position and 
     position of the enemy if i needs to for the save. Optional, i could also reset to the last previous of the reset of the game*/
    public void OnDestroy()
    {
        Debug.Log("GamePersist was destroy");
    }


    // Adds Score to the scoreboard its public take
    public void AddScore(int  s)
    {
        Score += s;
    }
    // gets the score from the class
    public int GetScore()
    {
        return Score;
     }

    //  
    /// <summary>
    ///gets the number of lives from the class 
    /// </summary>
    /// <return> number of lives</return>
    public int GetLives()
    {
        return Lives;
    }
   
     // calls the game over class this will be move to the load scene class

    public void gameover()
    {

            SceneManager.LoadScene("GameOver");    
    }


    void Update()
    {

    }
}
