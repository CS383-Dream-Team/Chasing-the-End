using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class used for the item script containg information for the inventory 
/// contains the get name, get image and onpickup for the items.
/// Must be added to each object that is to be added in the inventory in
/// the same format but each with its name and image
/// </summary>
public class Apple :MonoBehaviour, I_IventoryItem {

    /// <summary>
    /// each item must have a name that identifies it. 
    /// </summary>
    public string Name
    {
        get
        {
            return "Apple";
        }
    }


    /// <summary>
    /// assing  the image to be used in the icon of the inventory.
    /// will be used by the item as information for the inventory 
    ///set in the inspector as a sprite. 
    /// </summary>
    public Sprite _Image = null;

    /// <summary>
    /// The Event is called upon a event conditon that is collision with this 
    /// item. Upon it the object returns an image of the object as a Sprite. 
    /// </summary>
    /// <return> Sprite Image</return>
    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    /// <summary>
    /// Item Event is called after the item has been added to do the inventory. 
    /// this disables the item after being placed in the inventory from an event. 
    /// </summary>
    public void OnPickup()
    {
        gameObject.SetActive(false);
    }
}
