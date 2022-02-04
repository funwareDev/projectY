using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTester : MonoBehaviour
{
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private InventoryItemInfo[] _itemsInfo;
    [SerializeField] private int _inventorySize;

    [Header("Add")]
    [SerializeField] private InputField _ID;
    [SerializeField] private InputField _amount;
    [SerializeField] private Toggle _toggle;

    [Header("Remove")]
    [SerializeField] private InputField _ID2;
    [SerializeField] private InputField _amount2;

    private List<InventoryItem> _itemsDataBase;
    
    private void Start()
    {
        _itemsDataBase = new List<InventoryItem>();

        //initializing some items
        for (int i = 0; i < _itemsInfo.Length; i++)
        {
            _itemsDataBase.Add(new InventoryItem(_itemsInfo[i]));
        }
    }

    public void AddItem() 
    {
        int itemIndex = Int32.Parse(_ID.text), itemAmount = Int32.Parse(_amount.text);
        bool addInNewSlot = _toggle.isOn;
        
        if (addInNewSlot)
        {
            _playerInventory.Inventory.AddToEmptySlots(_itemsDataBase[itemIndex], itemAmount);
        }
        else
        {
            _playerInventory.Inventory.TryAdd(_itemsDataBase[itemIndex], itemAmount);
        }
    }

    public void RemoveItem()
    {
        int itemIndex = Int32.Parse(_ID2.text), itemAmount = Int32.Parse(_amount2.text);
        _playerInventory.Inventory.TryRemove(_itemsDataBase[itemIndex], itemAmount);
    }
}
