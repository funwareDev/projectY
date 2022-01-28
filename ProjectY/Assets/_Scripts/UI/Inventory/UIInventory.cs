using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{

    [SerializeField] private Transform _container;
    [SerializeField] private UIInventorySlot _inventorySlotPrefab;

    public IInventory _inventory { get; private set; }
    
    private List<UIInventorySlot> _uiSlots;

    public void Init(IInventory inventory)
    {
        _uiSlots = new List<UIInventorySlot>();

        _inventory = inventory;

        var slots = _inventory.GetAllSlots();
        for (int i = 0; i < _inventory.Capacity; i++)
        {
            var slot = Instantiate(_inventorySlotPrefab, _container);
            slot.Init(slots[i]);
            _uiSlots.Add(slot);
        }
    }
}
