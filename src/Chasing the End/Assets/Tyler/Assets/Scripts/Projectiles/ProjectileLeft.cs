using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLeft : Projectile {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        transform.position += ((transform.right)*-1) * Time.deltaTime * speed;
    }
}
