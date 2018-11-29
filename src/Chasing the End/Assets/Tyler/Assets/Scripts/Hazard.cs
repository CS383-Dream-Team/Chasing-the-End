using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Hazard Class is made to control projectile collision with the player.
/// If the saw blade sprite collides with the player with tag "Player" then the Gameover scene is loaded. 
/// If the saw blade contacts another game object, such as the enemies or a wall, the object is destroyed. 
/// The saw blade is also destroyed if the set time is met.
/// </summary>
public class Hazard : MonoBehaviour
{   
    void OnCollisionEnter2D(Collision2D coll)
    {
        //checking if blade collides with player tag
        if (coll.transform.tag == "Player")
        {
            //loads gameover scene if sprite collides with player
            SceneLoader sawBlade = new SceneLoader();
            sawBlade.Gameover();
        }
        else
        {
            //destroying the sprite depending on time or collision with objects other than player
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject, 0.1f);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}