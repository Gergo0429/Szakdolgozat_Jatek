using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryViewController : MonoBehaviour
{
    public GameObject itemPrefab;
    private List<Transform> thissChildren;
    private InventoryModelController inventoryModelController;
    private List<ItemModel> items;

    void Awake()
    {
        inventoryModelController = GameObject.Find("Inventory").GetComponent<InventoryModelController>();
        thissChildren = new List<Transform>();

        foreach (Transform child in transform)
        {
            thissChildren.Add(child);
        }

        PopulateGrid();
    }

    void OnEnable()
    {
        PopulateGrid();
    }

    public void PositionChanged(int index1, int index2)
    {
        inventoryModelController.SwitchItems(index1, index2);
    }

    public void PopulateGrid()
    {
        items = inventoryModelController.GetAllItems();

        for (int i = 0; i < items.Count; i++)
        {
            if (!string.IsNullOrEmpty(items[i].itemName))
            {
                foreach (Transform child in thissChildren[i])
                {
                    Destroy(child.gameObject);
                }

                GameObject newItem = Instantiate(itemPrefab, thissChildren[i]);

                newItem.GetComponent<InventoryItemView>().SetIcon(items[i].icon);
                newItem.GetComponent<InventoryItemView>().SetQuantity(items[i].quantity);
            }
            else
            {
                foreach (Transform child in thissChildren[i])
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
}
