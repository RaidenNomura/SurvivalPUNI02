using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    #region Exposed

    [SerializeField] Image _image;
    [SerializeField] Color _selectedColor, _notSelectedColor;

    #endregion

    private void Awake()
    {
        Deselect();
    }


    #region Methods

    public void Select()
    {
        _image.color = _selectedColor;
    }

    public void Deselect()
    {
        _image.color = _notSelectedColor;
    }


    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem._parentAfterDrag = transform;
        }
    }

    #endregion

    #region Private & Protected



    #endregion
}

