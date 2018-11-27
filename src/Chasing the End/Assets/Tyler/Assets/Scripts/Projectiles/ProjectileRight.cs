using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRight : Projectile {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }
}
