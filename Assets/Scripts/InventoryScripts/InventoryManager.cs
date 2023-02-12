using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    #region Exposed
    public InventorySlot[] inventorySlots;
    [SerializeField] GameObject inventoryItemPrefab;

    #endregion

    #region Unity Lifecycle

    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void Update()
    {
        // Check if any input is pressed then if it's a number, if it's superior to 0 and inferior to the number of slots
        // Then select the slot
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 5)
            {
                ChangeSelectedSlot(number - 1);
            }
        }
    }

    #endregion

    #region Methods

    public bool AddItem(Item item)
    {
        // Check if any slot has the same item with count lower than max
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot._item == item && itemInSlot._count < item.MaxStack && item._isStackable)
            {
                itemInSlot._count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        // Find any empty slot
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }

    // Spawn a new slot and a new item in the slot
    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    // Deselect the old slot then select the new one
    void ChangeSelectedSlot(int newValue)
    {
        if (_selectedSlot >= 0)
        {
            inventorySlots[_selectedSlot].Deselect();
        }
        inventorySlots[newValue].Select();
        _selectedSlot = newValue;
    }

    public Item GetSelectedItem(bool use)
    {
        InventorySlot slot = inventorySlots[_selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            Item item = itemInSlot._item;
            if (use)
            {
                itemInSlot._count--;
                if (itemInSlot._count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                }
                else
                {
                    itemInSlot.RefreshCount();
                }
            }
            return item;
        }
        return null;
    }

    #endregion

    #region Private & Protected

    int _selectedSlot = -1;

    #endregion
}
