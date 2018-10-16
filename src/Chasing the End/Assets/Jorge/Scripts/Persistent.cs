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


    public static Persistent GetInstance()
    {
        return FirstInstance;
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void OnDestroy()
    {
        Debug.Log("GamePersist was destroy");
    }


    // add to the score
    public void AddScore(int  s)
    {
        Score += s;
    }

    public int GetScore()
    {
        return Score;
     }


    public int GetLives()
    {
        return Lives;
    }
   
     
    public void gameover()
    {

            SceneManager.LoadScene("GameOver");    
    }


    void Update()
    {

    }
}
