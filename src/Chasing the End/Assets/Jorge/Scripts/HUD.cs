using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour {

    // Inventory public used that allows the inventory prefab to be drop in the inspector. 
    // will receive the status of the inventory
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
            // gets the image componet in the the ItemImage
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
         
            // checks if the image was previously enable
            if (!image.enabled && image.sprite == null)
            {
              
               // Debug.Log(sender.ToString());
                image.enabled = true;
                image.sprite = e.Item.Image;

                break;
            }
        }
    }

}
