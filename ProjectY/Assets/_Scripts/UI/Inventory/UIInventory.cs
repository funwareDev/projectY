using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private PlayerInventory _playerInventory;

    private IInventory _inventory;
    
    private List<UIInventorySlot> _uiSlots;

    public void Init(IInventory inventory)
    {
        _inventory = inventory;
        _uiSlots = _container.GetComponentsInChildren<UIInventorySlot>().ToList();
        var slots = _inventory.GetAllSlots();

        for (int i = 0; i < _inventory.Capacity; i++)
        {
            _uiSlots[i].Init(slots[i]);
            _uiSlots[i].UIInventoryItem.ItemDrop += OnItemDrop;
        }
    }

    public void TransferFromSlotToSlot(UIInventorySlot from, UIInventorySlot to) 
    {
        _inventory.TransferFromSlotToSlot(from.InventorySlot, to.InventorySlot);
    }

    public void OnItemDrop(UIInventorySlot uiInventorySlot) 
    {
        _playerInventory.DropItem(uiInventorySlot.InventorySlot);
    }
}
