using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    [SerializeField] Image _image;
    [SerializeField] TextMeshProUGUI _countText;

    [HideInInspector]
    public Item _item;
    [HideInInspector]
    public int _count = 1;
    [HideInInspector]
    public Transform _parentAfterDrag;

    public TextMeshProUGUI CountText { get => _countText; set => _countText = value; }

    public void InitialiseItem(Item newItem)
    {
        _item = newItem;
        _image.sprite = newItem._image;
        RefreshCount();
    }

    public void RefreshCount()
    {
        _countText.text = _count.ToString();
        bool textActive = _count > 1;
        _countText.gameObject.SetActive(textActive);
    }

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
