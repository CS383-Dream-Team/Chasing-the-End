using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The MovementController class contains the functionality for character movement.
/// </summary>
/// <remarks>
/// MovementController requires the GameObject to have a Rigidbody component.
/// </remarks>
[RequireComponent(typeof(Rigidbody))]
public class MovementController : MonoBehaviour, IMovementController
{
    /// <summary>
    /// Start() is called on the frame when a script is enabled just before any of the "Update" methods are called the first time.
    /// This method sets the _rigidBody field to our character's rigidBody component.
    /// </summary>
    public void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// FixedUpdate() is called every fixed framerate frame.
    /// This method calls the MoveCharacter() method.
    /// </summary>
    public void FixedUpdate()
    {
        MoveCharacter();
    }

    /// <summary>
    /// This method changes the character's velocity given any combination of "Horizontal" and "Vertical" input, simulating character movement.
    /// </summary>
    /// <remarks>
    /// GetAxisRaw returns the value of the virtual axis with no smoothing filter applied. This provides less "floaty" character movement which is preferred.
    /// </remarks>
    public void MoveCharacter()
    {
        Vector2 updateVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _rigidBody.velocity = updateVelocity * _characterSpeed;
    }

    private readonly float _characterSpeed = 10.0f;
    private Rigidbody2D _rigidBody;
}
