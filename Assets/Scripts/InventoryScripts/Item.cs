using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{

    

    [Header("Only gameplay")]
    public ItemType _type;
    public ActionType _actionType;
    public Vector2Int _range = new Vector2Int(5, 4);

    [Header("Only UI")]
    public bool _isStackable = true;

    [Header("Both")]
    public Sprite _image;
    [SerializeField] byte _maxStack;

    public byte MaxStack { get => _maxStack; set => _maxStack = value; }
}

public enum ItemType
{
    Weapon,
    Armor,
    Consumable,
    Quest,
    Key,
    Other

}

public enum ActionType
{
    Melee,
    Ranged,
    Magic,
    Other
}