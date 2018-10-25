using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

    public void loadTest1()
    {
        SceneManager.LoadScene(1);
    }

    public void loadTest2()
    {
        SceneManager.LoadScene(2);
    }

    public void loadTest3()
    {
        SceneManager.LoadScene(3);
    }
    public void loadTest4()
    {
        SceneManager.LoadScene(4);
    }
    public void loadTest5()
    {
        SceneManager.LoadScene(5);
    }

    public void quitTest()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

}
