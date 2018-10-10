using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyMovement : MonoBehaviour {

    public float speed;         //Moving speed for the enemy
    private Transform player;   //The player
    public float distanceToStop;
    private bool facingRight = false;

      void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.name == "Player")
        {
             SceneManager.LoadScene("GameOver");
        }
    }

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();      //Object with the player tag
	}
	
	void Update () { //Move the enemy towsrds the player
        float horizontal = Input.GetAxis("Horizontal");
        if (Vector2.Distance(transform.position, player.position) > distanceToStop) //If statement added so that the enemy is not on top of the player when they collide
        {                                                                   //If the distance is > than 1.5 enemy will continue moving
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
      if(player.position.x > transform.position.x && !facingRight){
        Flip();
        facingRight=true;
     }else if(player.position.x < transform.position.x && facingRight ){
        Flip();
        facingRight=false;
     }  
	}
    private void Flip()
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
}