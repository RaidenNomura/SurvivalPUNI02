using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    [SerializeField] Image _image;

    [HideInInspector]
    public Transform _parentAfterDrag;
    
    //private Transform _parentAfterDrag;

    //public Transform ParentAfterDrag { get => _parentAfterDrag; set => _parentAfterDrag = value; }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _image.raycastTarget = false;
        _parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _image.raycastTarget = true;
        transform.SetParent(_parentAfterDrag);
    }

}
