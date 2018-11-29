using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{   
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "Player")
        {
            SceneLoader sawBlade = new SceneLoader();
            sawBlade.Gameover();

        }
        else
        {
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