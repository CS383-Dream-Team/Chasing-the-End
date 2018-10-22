using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Apple :MonoBehaviour, I_IventoryItem {



    public string Name
    {
        get
        {
            return "Apple";
        }
    }


    public Sprite _Image = null;

    public Sprite Image
    {
        
        get
        {
            return _Image;
        }
    }

    public void OnPickup()
    {
        gameObject.SetActive(false);
    }
}
