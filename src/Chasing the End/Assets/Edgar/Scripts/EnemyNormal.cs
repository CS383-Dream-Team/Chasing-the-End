/*
 * This is the script that is assigned to both the normal enemy and the boss enemy.
 * A second script for the boss enemy was not becessary since the speed
 * is a global variable.
 */

using UnityEngine;

// Inheriting from the Enemy class
public class EnemyNormal : Enemy 
{
    // PLayer uses transform from Unity to update player x and y position.
	public void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update() 
    {
        // Distance to stop must be 0 if OnCollisionEnter2D has been implemented.
        if (Vector2.Distance(transform.position, player.position) > distanceToStop)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        /* 
         * If statements designed to flip the character left and right to face the player.
         * They use the character position, enemy position, and the facingRight bol.
         */
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
