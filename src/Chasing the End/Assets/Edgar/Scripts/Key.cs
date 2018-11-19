/*
 * This script was created by Jorge. I simply used the code to 
 * create a last minute fix for item interaction with the keys 
 * for the week 5 class Demo. 
 */
using UnityEngine;


/// <summary>
/// Class used for the item script containg information for the inventory 
/// contains the get name, get image and onpickup for the items.
/// Must be added to each object that is to be added in the inventory in
/// the same format but each with its name and image
/// </summary>
public class Key : MonoBehaviour, I_IventoryItem
{


    /// <summary>
    /// each item must have a name that identifies it. 
    /// </summary>
    public string Name
    {
        get
        {
            return "Key";
        }
    }

    /// <summary>
    /// This is to set the image to the object of this script belongs to. 
    /// Its passed from the inspector as a sprite image
    /// </summary>
    public Sprite imageFromObject = null;



    /// <summary>
    /// The Event is called upon a event conditon that is collision with this 
    /// item. Upon it the object returns an image of the object as a Sprite. 
    /// </summary>
    /// <return> Sprite Image</return>
    public Sprite Image
    {

        get
        {
            return imageFromObject;
        }
    }


    /// <summary>
    /// Item Event is called after the item has been added to do the inventory. 
    /// </summary>
    public void OnPickup()
    {
        gameObject.SetActive(false);
    }
}