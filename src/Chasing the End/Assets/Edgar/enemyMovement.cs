using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

    public float speed;         //Moving speed for the enemy
    private Transform player;   //The player
    public float distanceToStop;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();      //Object with the player tag
	}
	
	
	void Update () { //Move the enemy towsrds the player
        if (Vector2.Distance(transform.position, player.position) > distanceToStop) //If statement added so that the enemy is not on top of the player when they collide
        {                                                                   //If the distance is > than 1.5 enemy will continue moving
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
	}
}
