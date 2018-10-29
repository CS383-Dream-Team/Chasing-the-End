using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Inventory Interface for the the Inventory Class that is used for each of the items 
/// that will be loaded this is used by the inventory and and the items.
/// </summary>
public interface I_IventoryItem
{
    string Name { get; }

    Sprite Image { get; }

    void OnPickup();
}


public class InventoryEventArgs : EventArgs
{

    public InventoryEventArgs(I_IventoryItem item)
    {
        Item = item;
    }

    public I_IventoryItem Item;

}
