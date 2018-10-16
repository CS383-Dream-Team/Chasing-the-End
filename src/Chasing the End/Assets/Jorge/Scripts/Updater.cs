using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Updater : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {

        /*           
                    GameObject go = GameObject.Find("GamePersistent");
                     if(go ==  null )
                    {
                        Debug.Log("Failed to find an object name gamePersistenet ");
                           this.enabled = false; 
                            return;
                    }
                  Persistent per   = go.GetComponent<Persistent>();

                    GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + per.GetScore() + " Lives: " + per.GetLives();

        */

        // this works faster than having to fing the object
        GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + Persistent.GetInstance().GetScore() + " Lives: " + Persistent.GetInstance().GetLives();

    
    }
}
