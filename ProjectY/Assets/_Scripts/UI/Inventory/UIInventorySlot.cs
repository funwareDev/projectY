using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

class UIInventorySlot : MonoBehaviour
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private Text _amountText;

    private IInventorySlot _inventorySlot;

    public void Init(IInventorySlot inventorySlot)
    {
        _inventorySlot = inventorySlot;
        _inventorySlot.SlotChanged += Refresh;
        Refresh();
    }

    public void Refresh()
    {
        if (_inventorySlot.IsEmpty) 
        {
            _iconImage.gameObject.SetActive(false);
            _amountText.text = "0";
            return;
        }
        else
        {
            _iconImage.gameObject.SetActive(true);
        }

        _iconImage.sprite = _inventorySlot.Item.ItemInfo.Icon;
        _amountText.text = _inventorySlot.Amount.ToString();
    }
}

