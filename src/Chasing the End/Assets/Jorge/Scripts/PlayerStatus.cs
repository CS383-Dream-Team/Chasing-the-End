using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour {


	private Vector2 pos; 
	private float score;
    private Scene scneNumber;

	 void GetInfo () {

        pos = transform.position;
        scneNumber = SceneManager.GetActiveScene();

        Debug.Log(pos);
        Debug.Log(scneNumber);
	}


	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
        GetInfo();
		
	}
}
