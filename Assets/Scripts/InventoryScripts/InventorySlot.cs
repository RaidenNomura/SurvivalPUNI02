using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    #region Exposed

    #endregion


    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem._parentAfterDrag = transform;
        }
    }

    #region Methods

    #endregion

    #region Private & Protected



    #endregion
}

