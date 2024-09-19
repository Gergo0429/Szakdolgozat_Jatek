using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryViewController : MonoBehaviour
{
    public GameObject itemPrefab;
    private List<Transform> thissChildren;
    private InventoryModelController inventoryModelController;
    private ZoomedView zoomedView;
    private string zoomedItem;
    private List<ItemModel> items;

    void Awake()
    {
        inventoryModelController = GameObject.Find("Inventory").GetComponent<InventoryModelController>();
        thissChildren = new List<Transform>();
        zoomedView = GameObject.Find("ZoomedView").GetComponent<ZoomedView>();

        foreach (Transform child in transform)
        {
            thissChildren.Add(child);
        }
    }

    void OnEnable()
    {
        items = inventoryModelController.GetAllItems();
        if (items.Find(item => item.itemName == zoomedItem) == null)
        {
            zoomedView.SetEmpty();
        }
        PopulateGrid();
    }

    public void PositionChanged(int index1, int index2)
    {
        inventoryModelController.SwitchItems(index1, index2);
    }

    public void Clicked(int index)
    {
        items = inventoryModelController.GetAllItems();
        zoomedItem = items[index].itemName;
        zoomedView.SetName(Lean.Localization.LeanLocalization.GetTranslationText(items[index].itemName));
        zoomedView.SetImage(items[index].image);
    }

    public void PopulateGrid()
    {
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
