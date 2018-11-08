using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Main enemy class
public class Enemy : MonoBehaviour 
{
    protected Transform player; 
    public static float distanceToStop = 0;
    public float speed;
    protected bool facingRight = false;

    /// <summary>
    ///Unity on collison function, using the player tag
    /// to detect collision btween "player" and "enemy"
    /// </summary>
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

      
    /// <summary>
    /// This is a function to flip the enemy ledt and right
    /// When following the player
    /// </summary>
    public void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

