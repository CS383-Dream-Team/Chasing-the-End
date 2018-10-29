using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    // is the amount of slots in the inventory.
    private const int SLOTS = 8;
    // a list of type inventory only avaliable to this class
    private List<I_IventoryItem> mItems = new List<I_IventoryItem>();

    // Event listener for when an item is added
    public event EventHandler<InventoryEventArgs> ItemAdded;


    /// <summary>
    /// This function adds a new item to the list to the list it also calls the inventoryEventArgs 
    /// to be displayed in the inventory.  
    /// </summary>
    /// <param name="item"> Requires an object of type I_IventoryItem</param>
    public void AddItem(I_IventoryItem item)
    {
        //  checks to make sure that no more items can be added than the max slots
        if (mItems.Count < SLOTS)
        {

            // gets the collider properti from the item as a MonoBehavior insted of the I_IventoryItem
            Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D>();

            // If the Item collider is set on the item colider will be disable and the item will  be added to 
            // list of mItems  and the item onpickup is called which disables the object
            if (collider.enabled)
            {
                collider.enabled = false;
                mItems.Add(item);
                item.OnPickup();

                //calls the event for the item
                if (ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }
}
