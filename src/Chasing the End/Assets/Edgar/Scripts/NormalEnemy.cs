using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class inherits all from Enemy
public class NormalEnemy : Enemy 
{
	// Use this for initialization
	public void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update () 
    {
        //Distance to stop was set to 0 after implementing on collision
        if (Vector2.Distance(transform.position, player.position) > distanceToStop)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        if (player.position.x > transform.position.x && !facingRight)
        {
            Flip();
            facingRight = true;
        }

        else if (player.position.x < transform.position.x && facingRight)
        {
            Flip();
            facingRight = false;
        }
    }
}
