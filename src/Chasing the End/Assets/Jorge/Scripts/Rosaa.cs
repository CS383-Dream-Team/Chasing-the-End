using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Rosaa : MonoBehaviour, I_IventoryItem
{



    public string Name
    {
        get
        {
            return "Rosaa";
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

