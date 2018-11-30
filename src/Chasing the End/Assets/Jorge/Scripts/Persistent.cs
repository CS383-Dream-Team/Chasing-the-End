using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary> this class is used in a singleton pattern there can only one instance
/// of this class to maintain the numbers of items score or lives.
/// this class is attached to an object that is persistent throught the 
/// loading of scenes. The class checks everytime a new scene is loaded to 
/// see if its the only active Scene. If this is the first one its set, then
/// next scene that is loaded it will check again but if there is an already 
/// active instance it will autodestroy to keep the first one only. 
/// can keep track of items or objects througt loading screens. 
/// </summary>
public class Persistent : SceneLoader
{
    static protected Scene currentScene;
    protected string nowScene;
    protected string retryPoint;
    static protected List<I_IventoryItem> inventoryItems;

    static Persistent FirstInstance;    //Static first instance is the only instance in the game 
                                        // its only created once in anyothers will be destroyed

    // Use this for initialization
    void Start()
    {
        if (FirstInstance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        FirstInstance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        SavecurrentScene();
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

    /* this gets called when the objects is about to be destroy i could save the player position and 
     position of the enemy if i needs to for the save. Optional, i could also reset to the last previous of the reset of the game*/
    public void OnDestroy()
    {
        //Debug.Log("GamePersist was destroy");
    }

    public void SavecurrentScene()
    {
        nowScene = getCurrentSceneName();
        retryPoint = nowScene;
    }

    /// <summary>
    ///  gets the last scene. This can be used to for the retry point from the class
    /// </summary>
    /// <returns>Last Scene Name </returns>
    public string GetRetryPoint()
    {
        return retryPoint;
    }

}
