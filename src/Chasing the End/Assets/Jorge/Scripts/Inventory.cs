using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour {

    private const int SLOTS = 8;
    private List<I_IventoryItem> mItems = new List<I_IventoryItem>();
    public event EventHandler<InventoryEventArgs> ItemAdded; 


    public void AddItem(I_IventoryItem item)
    {
        Debug.Log(mItems.Count.ToString());
        if (mItems.Count < SLOTS)
        {
            Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D>();
            if(collider.enabled)
            {
                collider.enabled = false;
                mItems.Add(item);
                item.OnPickup();

                if (ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }
}
