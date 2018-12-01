/*
 * This is the main enemy class used to set the following variables and bool:
 * speed, player, distanceToStop, and facingRight.
 * The only variable that can be chamged is the speed of the enemy.
 */

using UnityEngine;
using UnityEngine.SceneManagement;

// DistanceToStop float should remain 0 unless onCollisionEnter2D is removed.
public class Enemy : MonoBehaviour 
{
    // Transform player is defined in the inherited files and contains the characters x and y position.
    protected Transform player;
    // distanceToStop can be increased so player and enemy don't collide.
    public static float distanceToStop = 0;
    // speed is a public var that can be changed in the isnpector in Unity.
    public float speed;
    // facingRight changes in the inherited files as enemy follows main character. 
    protected bool facingRight = false;

    /// <summary>
    /// Unity on collison function. The main character must have the "Player" tag
    /// for this function to work properly. OnCollision working properly will trigger
    /// the "GameOver" scene.
    /// </summary>
    virtual public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    /// <summary>
    /// This function will flip the enemy to face correctly left or right when
    /// following the main character. To do so, it multiplies the x position by -1.
    /// </summary>
    virtual public void Flip()
    {
        Vector3 directionFacing = transform.localScale;
        directionFacing.x *= -1;
        transform.localScale = directionFacing;
    }
}

