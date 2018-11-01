using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterControllerone
{
    void MoveCharacter();
    


}

public class PlayerMovementone : MonoBehaviour, IMovementController
{
    public Inventory inventory;

    // Called during initialization.
    public void Start()
    {
        //Set our rigidbody property.
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        MoveCharacter();
    }

    public void MoveCharacter()
    {
        //Get the current velocity from our rigidbody property.
        Vector2 velocity = _rigidbody.velocity;

        if (Input.GetAxisRaw("Vertical") > 0.0f)
        {
            velocity.y = _speed;
        }
        else if (Input.GetAxisRaw("Vertical") < 0.0f)
        {
            velocity.y = -_speed;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0.0f)
        {
            velocity.x = -_speed;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0.0f)
        {
            velocity.x = _speed;
        }
        else
        {
            velocity.y = 0;
            velocity.x = 0;
        }

        //Set the rigidbody property to our new velocity.
        _rigidbody.velocity = velocity;
    }

    /// <summary>
    /// This Function is called when the player collides with an item. IF 
    /// the item has componet of type I_IventoruItem than i gets added to the 
    /// inventory.
    /// </summary>
    /// <param name="hit"> Colllision2D details of the item</param>
    private void OnCollisionEnter2D(Collision2D hit)
    {

        I_IventoryItem item = hit.gameObject.GetComponent<I_IventoryItem>();
        // if the item is the script the item proceds to call the iventory
        if (item != null)
        {
            // reference to the Additem function in the class inventory 
            inventory.AddItem(item);
        }
    }

    private readonly float _speed = 10.0f;
    private Rigidbody2D _rigidbody;
}
