using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class HUD : MonoBehaviour
{

    // Inventory public used that allows the inventory prefab to be drop in the inspector. 
    // will receive the status of the inventory
    public Inventory Inventory;



    

    // Use this for initialization
    void Start()
    {

        Inventory.ItemAdded += IventoryScript_ItemAdded;
        Debug.Log(Inventory.getNumberOfItems());
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
                List<I_IventoryItem> temp = Inventory.GetItemsList();
                Debug.Log(temp.Count);
                Debug.Log(Inventory.GetItemsList());
                // Debug.Log(sender.ToString());
                image.enabled = true;
                image.sprite = e.Item.Image;

                break;
            }
        }
    }


    






    private void OnDestroy()
    {

        Persistent.GetInstance().SavecurrentScene();

    }

     void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
           // string jorge = GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            //Transform Parent = transform.Find("GameMenu");
            //Debug.Log(jorge);
            
            // GameObject one = GetComponent<GameMene>();

//            Parent.disable;
            //Debug.Log(Parent.GetChild(0).name);
            Debug.Log("calling the backspace button");
        }
    }



}
