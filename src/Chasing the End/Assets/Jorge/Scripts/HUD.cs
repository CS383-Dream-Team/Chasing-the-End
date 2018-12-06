using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class HUD : MonoBehaviour
{

    // Inventory public used that allows the inventory prefab to be drop in the inspector. 
    // will receive the status of the inventory
    public Inventory Inventory;
    public GameObject optionsPanel;

    // Use this for initialization
    void Start()
    {
        Inventory.ItemAdded += IventoryScript_ItemAdded;
        optionsPanel = GameObject.Find("InGameMenu");
      
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
                image.enabled = true;
                image.sprite = e.Item.Image;

                break;
            }
        }
    }

    // saves the scene before the scene is destroyed.
    private void OnDestroy()
    {
        Persistent.GetInstance().SavecurrentScene();
    }

     void Update()
    {
        // call for displaying the options menu while the player plays
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            optionsPanel.gameObject.SetActive(true);
        }
    }

}
