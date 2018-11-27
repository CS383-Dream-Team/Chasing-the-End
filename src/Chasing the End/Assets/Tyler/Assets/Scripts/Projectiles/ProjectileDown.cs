using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inherit Speed field from Projectile but allows new direction.
public class ProjectileDown : Projectile {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.up * Time.deltaTime * speed;
    }
}
