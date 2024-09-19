using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemModel
{
    public string itemName;
    public int quantity;
    public Sprite icon;
    public Sprite image;

    public ItemModel()
    {
        this.itemName = null;
        this.quantity = 0;
        this.icon = null;
        this.image = null;
    }

    public ItemModel(ItemModel other)
    {
        itemName = other.itemName;
        quantity = other.quantity;
        icon = other.icon;
        image = other.image;
    }
}
