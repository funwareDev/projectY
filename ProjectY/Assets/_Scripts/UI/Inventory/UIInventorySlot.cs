using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventorySlot : MonoBehaviour, IDropHandler
{
    public IInventorySlot InventorySlot { get; set; }
    public UIInventoryItem UIInventoryItem { get; set; }

    private UIInventory _uiInventory;

    private void Awake()
    {
        _uiInventory = GetComponentInParent<UIInventory>();
        UIInventoryItem = GetComponentInChildren<UIInventoryItem>();
    }

    public void Init(IInventorySlot inventorySlot)
    {
        Awake();
        InventorySlot = inventorySlot;
        InventorySlot.SlotChanged += Refresh;
        Refresh();
    }

    public void OnDrop(PointerEventData eventData)
    { 
        var otherItemUI = eventData.pointerDrag.GetComponent<UIInventoryItem>();
        var otherSlotUI = otherItemUI.GetComponentInParent<UIInventorySlot>();

        _uiInventory.TransferFromSlotToSlot(otherSlotUI, this);
    }

    public void Refresh()
    {
        if (InventorySlot.IsEmpty)
        {
            UIInventoryItem.IconImage.gameObject.SetActive(false);
            UIInventoryItem.AmountText.gameObject.SetActive(false);
            return;
        }
        else
        {
            UIInventoryItem.IconImage.gameObject.SetActive(true);
            UIInventoryItem.AmountText.gameObject.SetActive(true);
        }

        UIInventoryItem.IconImage.sprite = InventorySlot.Item.ItemInfo.Icon;
        UIInventoryItem.AmountText.text = InventorySlot.Item.Amount.ToString();
    }
}
