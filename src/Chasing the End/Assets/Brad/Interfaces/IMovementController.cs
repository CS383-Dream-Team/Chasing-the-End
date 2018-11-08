using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementController
{
    void MoveCharacter();
    IEnumerator Dash();
    void UpdateMovementAnimation();
}
