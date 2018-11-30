using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The MovementData class contains the data necessary for character movement.
/// </summary>
/// <remarks>
/// We obfuscate the data used for character movement to reduce exposure of attributes by limiting their visibilty. This encapsulates
/// the data and allows us to remove write privilege of the attributes that get set only during construction. We also use the singleton design
/// pattern here to ensure that the class has only one instance with a globally accessable point of access. This also allows for lazy initalization,
/// should it be desired.
/// </remarks>
public class MovementData
{
    #region Constructors

    //Private constructor prevents outside instantiation, making this class responsible for it's own instantiation.
    private MovementData()
    {
        _characterSpeed = 10.0f;
        _dashSpeed = 20.0f;
        _dashDuration = 0.2f;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// This method provides a globally available accessor function for getting our single MovementData instance.
    /// </summary>
    public static MovementData GetMovementData()
    {
        return _singletonInstance;
    }

    /// <summary>
    /// This property expoeses the _characterSpeed field.
    /// </summary>
    public float CharacterSpeed
    {
        get { return _characterSpeed; }
    }

    /// <summary>
    /// This property exposes the _dashSpeed field.
    /// </summary>
    public float DashSpeed
    {
        get { return _dashSpeed; }
    }

    /// <summary>
    /// This property exposes the _dashDuration field.
    /// </summary>
    public float DashDuration
    {
        get { return _dashDuration; }
    }

    #endregion

    #region Private Fields

    private readonly float _characterSpeed;
    private readonly float _dashSpeed;
    private readonly float _dashDuration;
    private static readonly MovementData _singletonInstance = new MovementData();

    #endregion
}
