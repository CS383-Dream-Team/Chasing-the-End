using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The ItemInteractionController class contains the functionality for character item interaction.
/// </summary>
/// <remarks>
/// It's the developers responsibility to assign the Inventory field to the appropriate Inventory GameObject in the scene.
/// </remarks>
public class ItemInteractionController : MonoBehaviour, IItemInteractionController
{
    #region Public Methods

    /// <summary>
    /// This method verifies that the _item field isn't null (in the case it wasn't a valid item) and that the user is attempting to "pickup" the item,
    /// then adds the item to the character's inventory.
    /// </summary>
    public void PickupItem()
    {
        if (_item != null && Input.GetButtonDown("Pickup"))
        {
            Inventory.AddItem(_item);
        }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// This method updates the value of _item if we are entering the trigger of a valid item.
    /// </summary>
    /// <remarks>
    /// OnTriggerEnter2D() is called when another object enters a trigger collider attached to another object.
    /// </remarks>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _item = collision.gameObject.GetComponent<I_IventoryItem>();
    }

    /// <summary>
    /// This method calls the appropriate method for item pickup.
    /// </summary>
    /// <remarks>
    /// OnTriggerEnter2D() is called when another object is within a trigger collider attached to another object.
    /// </remarks>
    private void OnTriggerStay2D(Collider2D collision)
    {
        PickupItem();
    }

    #endregion

    #region Public Fields

    public Inventory Inventory;

    #endregion

    #region Private Fields

    private I_IventoryItem _item;

    #endregion
}
