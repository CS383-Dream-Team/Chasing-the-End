using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Called during initialization.
    public void Start()
    {
        //Set our rigidbody property.
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame.
    public void Update()
    {
        //Get the current velocity from our rigidbody property.
        Vector2 velocity = _rigidbody.velocity;

        if (Input.GetKey(_moveUp))
        {
            velocity.y = _speed;
        }
        else if (Input.GetKey(_moveDown))
        {
            velocity.y = -_speed;
        }
        else if (Input.GetKey(_moveLeft))
        {
            velocity.x = -_speed;
        }
        else if (Input.GetKey(_moveRight))
        {
            velocity.x = _speed;
        }
        else
        {
            velocity.y = 0;
            velocity.x = 0;
        }

        //Set the rigidbody property to our new velocity.
        _rigidbody.velocity = velocity;
    }

    //These are the fields we want to make visible to the inspector.
    [SerializeField]
    private KeyCode _moveUp = KeyCode.W;
    [SerializeField]
    private KeyCode _moveDown = KeyCode.S;
    [SerializeField]
    private KeyCode _moveLeft = KeyCode.A;
    [SerializeField]
    private KeyCode _moveRight = KeyCode.D;
    [SerializeField]
    private float _speed = 10.0f;

    private Rigidbody2D _rigidbody;
}
