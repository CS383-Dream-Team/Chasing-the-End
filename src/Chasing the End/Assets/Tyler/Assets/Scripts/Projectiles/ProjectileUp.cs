using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inherit Speed field from Projectile but allows new direction.
public class ProjectileUp : Projectile {

	// Use this for initialization
	void Start ()
    {
		
	}

    // Setting direction of projectile to be shot
    void Update ()
        {
            transform.position += transform.up * Time.deltaTime * speed;
        }
}
