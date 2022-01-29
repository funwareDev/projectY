using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTester : MonoBehaviour
{
    private IInventory _inventory;

    [SerializeField] private UIInventory _uiInventory;
    [SerializeField] private InventoryItemInfo[] _itemDataArr;

    [Header("Add")]
    [SerializeField] private InputField _ID;
    [SerializeField] private InputField _amount;

    [Header("Remove")]
    [SerializeField] private InputField _ID2;
    [SerializeField] private InputField _amount2;

    private List<InventoryItem> _items;
    
    private void Start()
    {
        _inventory = new Inventory(16);
        _uiInventory.Init(_inventory);

        _items = new List<InventoryItem>();

        //initializing some items
        for (int i = 0; i < _itemDataArr.Length; i++)
        {
            _items.Add(new InventoryItem(_itemDataArr[i]));
        }
    }

    public void AddItem() 
    {
        int itemIndex = Int32.Parse(_ID.text), itemAmount = Int32.Parse(_amount.text);
        _inventory.TryAdd(_items[itemIndex], itemAmount);
    }

    public void RemoveItem()
    {
        int itemIndex = Int32.Parse(_ID2.text), itemAmount = Int32.Parse(_amount2.text);
        _inventory.TryRemove(_items[itemIndex], itemAmount);
    }
}
