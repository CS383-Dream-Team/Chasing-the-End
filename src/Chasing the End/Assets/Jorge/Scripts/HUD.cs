using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour {


    public Inventory Inventory;


	// Use this for initialization
	void Start () {
        
        Inventory.ItemAdded += IventoryScript_ItemAdded;	
	}


    public void IventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
       
        Transform InventoryParent = transform.Find("Inventory");
        foreach (Transform slot in InventoryParent)
        {
            //Debug.Log(slot.GetChild(0).GetChild(0).GetComponent<Image>());
            

            // gets the image componet in the the ItemImage
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>(); 

            // checks if the image was previously enable
            if (!image.enabled)
            {
                Debug.Log("int being put");
                Debug.Log(sender.ToString());
                image.enabled = true;
                image.sprite = e.Item.Image;

                break;
            }
        }
    }

}
