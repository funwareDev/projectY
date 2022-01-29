using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Transform _container;

    public IInventory _inventory { get; private set; }
    
    private List<UIInventoryItem> _uiSlots;

    public void Init(IInventory inventory)
    {
        _inventory = inventory;
        _uiSlots = _container.GetComponentsInChildren<UIInventoryItem>().ToList();
        var slots = _inventory.GetAllSlots();

        for (int i = 0; i < _inventory.Capacity; i++)
        {
            _uiSlots[i].Init(slots[i]);
        }
    }
}
