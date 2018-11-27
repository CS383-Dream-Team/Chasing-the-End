using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inherit Speed field from Projectile but allows new direction.
public class ProjectileLeft : Projectile {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * speed;
    }
}
