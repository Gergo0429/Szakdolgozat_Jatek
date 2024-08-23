using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModelController : MonoBehaviour
{
    private const int MaxItems = 11;
    private List<ItemModel> items = new List<ItemModel>(MaxItems);

    void Start()
    {
        for (int i = 0; i < MaxItems; i++)
        {
            items.Add(new ItemModel());
        }
    }

    public int FindIndexByName(string itemName)
    {
        for (int i = 0; i < MaxItems; i++)
        {
            if (items[i].itemName == itemName)
                return i;
        }
        return -1;
    }

    public bool AddItem(ItemModel item)
    {
        int firstEmptyPlace = -1;
        bool added = false;

        for (int i = 0; i < MaxItems; i++)
        {
            if (items[i].itemName == null && firstEmptyPlace == -1)
            {
                firstEmptyPlace = i;
            }
            if (items[i].itemName == item.itemName)
            {
                items[i].quantity += item.quantity;
                added = true;
            }
        }

        if (!added)
        {
            if (firstEmptyPlace == -1)
            {
                return false;
            }
            else
            {
                items[firstEmptyPlace] = new ItemModel(item);
            }
        }

        return true;
    }

    public void SwitchItems(int index1, int index2)
    {
        ItemModel swItem = items[index1];
        items[index1] = items[index2];
        items[index2] = swItem;
    }

    public bool RemoveItem(string itemName)
    {
        int index = FindIndexByName(itemName);

        if (index > -1)
        {
            if (items[index].quantity > 1)
            {
                items[index].quantity--;
            }
            else if (items[index].quantity <= 1)
            {
                items[index] = new ItemModel();
            }
            return true;
        }
        return false;
    }

    public bool UseFromHand(string itemName)
    {
        if (items[MaxItems - 1].itemName == itemName)
        {
            items[MaxItems - 1] = new ItemModel();
            return true;
        }
        return false;
    }

    public List<ItemModel> GetAllItems()
    {
        return new List<ItemModel>(items);  // Return a copy of the list
    }
}
