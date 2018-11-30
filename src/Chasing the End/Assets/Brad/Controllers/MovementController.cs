using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The MovementController class contains the functionality for character movement.
/// </summary>
/// <remarks>
/// MovementController automatically adds a Rigidbody component and a SpriteRenderer component to the GameObject if they are missing.
/// </remarks>
[RequireComponent(typeof(Rigidbody), typeof(SpriteRenderer))]
public class MovementController : MonoBehaviour, IMovementController
{
    #region Public Methods

    /// <summary>
    /// This method sets the _rigidBody and _spriteRenderer field to those of our character's GameObject, and we create a reference for our MovementData instance.
    /// </summary>
    /// <remarks>
    /// Start() is called on the frame when a script is enabled just before any of the "Update" methods are called the first time.
    /// </remarks>
    public void Start()
    {
        _movementData = MovementData.GetMovementData();
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// This method calls the appropriate methods for character movement and dashing, then will update the character's animation to reflect the movement.
    /// </summary>
    /// <remarks>
    /// FixedUpdate() is called every fixed framerate frame.
    /// </remarks>
    public void FixedUpdate()
    {
        if (_allowDash && Input.GetButtonDown("Dash"))
        {
            StartCoroutine(Dash());
        }

        if (!_isDashing)
        {
            MoveCharacter();
        }

        UpdateMovementAnimation();
    }

    /// <summary>
    /// This method changes the character's velocity given any combination of "Horizontal" and "Vertical" input- simulating character movement.
    /// </summary>
    /// <remarks>
    /// GetAxisRaw returns the value of the virtual axis with no smoothing filter applied. This provides less "floaty" character movement which is preferred.
    /// </remarks>
    public void MoveCharacter()
    {
        Vector2 updateVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _rigidBody.velocity = updateVelocity * _movementData.CharacterSpeed;
    }

    /// <summary>
    /// This method changes the character's velocity given any combination of "Horizontal" and "Vertical" input at a speed higher than the character's normal movement speed- simulating a character dash.
    /// </summary>
    /// <remarks>
    /// A coroutine is a function that can suspend its execution (yield) until the given YieldInstruction finishes. This coroutine is resumed on the frame after it yields.
    /// </remarks>
    public IEnumerator Dash()
    {
        float elapsedDashTime = 0;

        _allowDash = false;
        _isDashing = true;

        while (_movementData.DashDuration > elapsedDashTime)
        {
            elapsedDashTime += Time.deltaTime;

            Vector2 updateVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            _rigidBody.velocity = updateVelocity * _movementData.DashSpeed;

            yield return null;
        }

        _allowDash = true;
        _isDashing = false;
    }

    /// <summary>
    /// This method checks the rigidBody's velocity and toggles the flipx property of the spriteRenderer accordingly so that the character is facing the direction of travel.
    /// </summary>
    public void UpdateMovementAnimation()
    {
        if (_rigidBody.velocity.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_rigidBody.velocity.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }

    #endregion

    #region Private Fields

    private bool _allowDash = true;
    private bool _isDashing = false;
    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private MovementData _movementData;

    #endregion
}
