using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InventoryItemView : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform startPosition;
    private Camera cam;
    private Image thisImage;
    private Color originalImageColor;
    private InventoryViewController viewController;

    void Awake()
    {
        thisImage = GetComponent<Image>();
        originalImageColor = thisImage.color;
        startPosition = transform.parent;
        cam = GameObject.Find("Inventory/InventoryPanel/Camera").GetComponent<Camera>();
        viewController = transform.parent.parent.GetComponent<InventoryViewController>();
    }

    public void SetIcon(Sprite icon)
    {
        thisImage.sprite = icon;
    }

    public void SetQuantity(int quantity)
    {
        if (quantity > 1)
        {
            this.GetComponentInChildren<TextMeshProUGUI>().text = "x" + quantity.ToString();
        }
        else
        {
            this.GetComponentInChildren<TextMeshProUGUI>().text = "";
        }

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        thisImage.raycastTarget = false;
        transform.SetParent(transform.parent.parent);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 screenPosition = eventData.position;
        screenPosition.z = cam.WorldToScreenPoint(transform.position).z;
        Vector3 worldPosition = cam.ScreenToWorldPoint(screenPosition);
        transform.position = worldPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(startPosition);
        thisImage.raycastTarget = true;
    }

    public void OnPointerEnter()
    {
        Color darkenedColor = new Color(originalImageColor.r * 0.5f, originalImageColor.g * 0.5f, originalImageColor.b * 0.5f, originalImageColor.a);
        thisImage.color = darkenedColor;
    }

    public void OnPointerExit()
    {
        thisImage.color = originalImageColor;
    }

    public void OnClick()
    {
        viewController.Clicked(transform.parent.GetSiblingIndex());
    }
}
