using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The CameraController class contains the functionality for the camera's functionality.
/// </summary>
/// /// <remarks>
/// It's the developers responsibility to assign the Character field to the appropriate Character GameObject in the scene.
/// </remarks>
public class CameraController : MonoBehaviour, ICameraController
{
    #region Public Methods

    /// <summary>
    /// This method calls the appropriate method for camera smoothing.
    /// </summary>
    /// <remarks>
    /// FixedUpdate() is called every fixed framerate frame.
    /// </remarks>
    public void FixedUpdate()
    {
        SmoothCameraMovement();
    }

    /// <summary>
    /// This method creates a target position relative to our character, and applies a smooth camera transform to that position. 
    /// </summary>
    public void SmoothCameraMovement()
    {
        Vector3 targetPosition = Character.TransformPoint(_transformPointPosition);
        transform.position = Vector3.SmoothDamp(current: transform.position, target: targetPosition, currentVelocity: ref _velocity, smoothTime: _smoothingTime);
    }

    #endregion

    #region Public Fields

    public Transform Character;
    
    #endregion

    #region Private Fields

    private readonly float _smoothingTime = 0.2f;
    private Vector3 _velocity = Vector3.zero;
    private readonly Vector3 _transformPointPosition = new Vector3(0, 0, -10);

    #endregion
}
