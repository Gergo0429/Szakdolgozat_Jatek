using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        InventoryItemView item = eventData.pointerDrag.GetComponent<InventoryItemView>();
        if (item != null && transform.childCount == 0)
        {
            transform.parent.gameObject.GetComponent<InventoryViewController>().PositionChanged(item.startPosition.GetSiblingIndex(), transform.GetSiblingIndex());
            item.startPosition = transform;
        }
    }
}
