using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterController
{
    void MoveCharacter();
}

public class PlayerMovement : MonoBehaviour, ICharacterController
{
    // Called during initialization.
    public void Start()
    {
        //Set our rigidbody property.
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        MoveCharacter();
    }

    public void MoveCharacter()
    {
        //Get the current velocity from our rigidbody property.
        Vector2 velocity = _rigidbody.velocity;

        if (Input.GetAxisRaw("Vertical") > 0.0f)
        {
            velocity.y = _speed;
        }
        else if (Input.GetAxisRaw("Vertical") < 0.0f)
        {
            velocity.y = -_speed;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0.0f)
        {
            velocity.x = -_speed;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0.0f)
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

    private readonly float _speed = 10.0f;
    private Rigidbody2D _rigidbody;
}
