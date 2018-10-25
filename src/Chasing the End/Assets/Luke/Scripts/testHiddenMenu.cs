using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class testHiddenMenu : MonoBehaviour
{

    private string[] cheatCode;
    private int index;
    private bool cheat;
    private Camera m_MainCamera;

    void OnGUI()
    {
        if (cheat)
        {
            m_MainCamera = Camera.main;
            // draw the hidden menu
            GUI.Box(new Rect(20, 80, 240, 240), "Cheat Menu :-) ");
            if (GUI.Button(new Rect(40, 120, 200, 20), "Return to Main Menu"))
            {
                SceneManager.LoadScene(0);
            }
            if (GUI.Button(new Rect(40, 150, 200, 20), "Reset Level"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if (GUI.Button(new Rect(40, 180, 200, 20), "Close this Menu"))
            {
                cheat = false;
                index = 0;
            }
        }
    }

    void Start()
    {
        // The pass Code is "secret", user needs to input 
        // this word to show the hidden menu
        cheatCode = new string[] {
   "p",
   "o",
   "p",
  };
        index = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(cheatCode[index]))
            {
                // right input, check next digit
                index++;
            }
            else
            {
                // wrong input, restart from index 0
                index = 0;
            }
        }

        if (index == cheatCode.Length)
        {
            // cheat is ok, the hidden menu is now visible :-)
            cheat = true;
            index = 0;
        }
    }
}