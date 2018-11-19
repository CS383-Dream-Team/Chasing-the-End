/*
 * This script is assigned to the enemies that only move on the x axis(left and right).
 * The enemy flips and walks the opposite direction each time it collides with the wall. 
 */

using UnityEngine;
using UnityEngine.SceneManagement;

// edgeOfMap float must be changed if the map x position exceeds 100.
public class EnemyX : Enemy 
{
    private Vector2 bounds;
    private readonly float edgeOfMap = -100;

    /* 
     * New OnCollisionEnter2D() overwrites inherited function. This function is needed
     * because it calls Flip() if the enemy collides with the wall and calls
     * "gameOver" if collision happens with the main character. 
     */
    new void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Collisions")
        {
            Flip();
        }

        if (col.transform.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    /*
     * New Flip() overwrites inherited function. This is because this function also
     * changes the x bound that the enemy has to walk, aside from only changing the 
     * direction it's facing. 
     */
    new void Flip()
    {
        Vector2 directionFacing = transform.localScale;
        directionFacing.x *= -1;
        transform.localScale = directionFacing;
        bounds.x *= -1;
    }

    // Set vector bounds
    void Start() 
    {
        bounds = new Vector2(edgeOfMap, transform.position.y);
    }
	
    // Moves enemy left and right, between the bounds float. 
	void Update() 
    {
        transform.position = Vector2.MoveTowards(transform.position, bounds, speed * Time.deltaTime);
    }
}
