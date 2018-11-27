using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileUp : Projectile {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
        {
            transform.position += transform.up * Time.deltaTime * speed;
        }
}
