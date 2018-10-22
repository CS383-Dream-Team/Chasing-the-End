using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface I_IventoryItem
{
    string Name { get; }

    Sprite Image { get; }

    void OnPickup();
}


public class InventoryEventArgs : EventArgs {

    public InventoryEventArgs(I_IventoryItem item)
    {
        Item = item;
    }

    public I_IventoryItem Item;

}
