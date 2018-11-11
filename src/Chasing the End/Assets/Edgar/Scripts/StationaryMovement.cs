using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StationaryMovement : MonoBehaviour {
    private Vector3 target;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Collisions")
        {
            Flip();
        }
        if (col.gameObject.name == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    // Use this for initialization
    void Start () 
    {
        target = new Vector3(-100.0F, transform.position.y, 0.0f);
    }

    // Update is called once per frame
    void Update () 
    {
        transform.position = Vector2.MoveTowards (transform.position,target, 2 * Time.deltaTime);
    }

    private void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        target.x *= -1;
    }
}
