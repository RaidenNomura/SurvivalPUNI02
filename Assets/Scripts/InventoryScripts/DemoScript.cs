using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    #region Exposed

    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] Item[] itemsToPickup;

    #endregion

    #region Unity Lifecycle



    #endregion

    #region Methods

    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickup[id]);
        if (result)
        {
            Debug.Log("Item added to inventory");
        }
        else
        {
            Debug.Log("Inventory full");
        }
    }
    
    public void GetSelectedItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(false);
        if (receivedItem != null)
        {
            Debug.Log("Received Item : " + receivedItem);
        }
        else
        {
            Debug.Log("No item received");
        }
    }
    
    public void UseSelectedItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(true);
        if (receivedItem != null)
        {
            Debug.Log("Used Item : " + receivedItem);
        }
        else
        {
            Debug.Log("No item used");
        }
    }

    #endregion

    #region Private & Protected



    #endregion
}
