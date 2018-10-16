using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
}
