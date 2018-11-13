using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The MovementController class contains the functionality for character movement.
/// </summary>
/// <remarks>
/// MovementController requires the GameObject to have a Rigidbody component and a SpriteRenderer component.
/// </remarks>
[RequireComponent(typeof(Rigidbody), typeof(SpriteRenderer))]
public class MovementController : MonoBehaviour, IMovementController
{
    #region Public Methods

    /// <summary>
    /// This method sets the _rigidBody and _spriteRenderer field to those of our character's GameObject.
    /// </summary>
    /// <remarks>
    /// Start() is called on the frame when a script is enabled just before any of the "Update" methods are called the first time.
    /// </remarks>
    public void Start()
    {
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
        _rigidBody.velocity = updateVelocity * _characterSpeed;
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

        while (_dashDuration > elapsedDashTime)
        {
            elapsedDashTime += Time.deltaTime;

            Vector2 updateVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            _rigidBody.velocity = updateVelocity * _dashSpeed;

            yield return null;
        }

        _allowDash = true;
        _isDashing = false;
    }

    public Inventory inventory;

    /// <summary>
    /// This Function is called when the player collides with an item. IF 
    /// the item has componet of type I_IventoruItem than i gets added to the 
    /// inventory.
    /// </summary>
    /// <param name="hit"> Colllision2D details of the item</param>
    private void OnCollisionEnter2D(Collision2D hit)
    {

        I_IventoryItem item = hit.gameObject.GetComponent<I_IventoryItem>();
        // if the item is the script the item proceds to call the iventory
        if (item != null)
        {
            // reference to the Additem function in the class inventory 
            inventory.AddItem(item);
        }
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

    private readonly float _characterSpeed = 10.0f;
    private readonly float _dashSpeed = 20.0f;
    private readonly float _dashDuration = 0.2f;
    private bool _allowDash = true;
    private bool _isDashing = false;
    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;

    #endregion
}
