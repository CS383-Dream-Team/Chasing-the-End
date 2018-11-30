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
    protected Transform player; 
    public static float distanceToStop = 0;
    public float speed;
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

