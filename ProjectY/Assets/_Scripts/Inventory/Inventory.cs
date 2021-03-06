using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : IInventory
{
    [SerializeField] private List<InventorySlot> _slots;

    public int Capacity { get; private set; }
    public bool IsFull => _slots.All(slot => slot.IsFull);

    public event Action ItemAdded;
    public event Action ItemRemoved;

    public Inventory(int capacity)
    {
        _slots = new List<InventorySlot>();
        Capacity = capacity;

        for (int i = 0; i < capacity; i++)
        {
            _slots.Add(new InventorySlot());
        }
    }

    public IInventoryItem GetItem(int itemID)
    {
        return _slots.Find(slot => slot.Item.ID == itemID).Item;
    }

    public IInventoryItem[] GetAllItems()
    {
        List<IInventoryItem> items = new List<IInventoryItem>();
        foreach (var slot in _slots)
        {
            if (!slot.IsEmpty)
                items.Add(slot.Item);
        }

        return items.ToArray();
    }

    public IInventoryItem[] GetAllItemsOfType(int itemID)
    {
        return _slots.Where(slot => slot.Item.ID == itemID && !slot.IsEmpty)
            .Select(slot => slot.Item).ToArray();
    }

    public int GetItemAmount(int itemID)
    {
        int amount = 0;
        foreach (var slot in _slots)
        {
            if (!slot.IsEmpty && slot.Item.ID == itemID)
                amount += slot.Amount;
        }
        return amount;
    }

    public IInventorySlot[] GetAllSlots()
    {
        return _slots.ToArray();
    }

    public bool HasItem(int itemID, out IInventoryItem item)
    {
        item = _slots.Where(slot => !slot.IsEmpty && slot.Item.ID == itemID)
            .FirstOrDefault().Item;

        return item == null;
    }

    public bool TryAdd(IInventoryItem item, int amount)
    {
        int availableAmount = 0, newAmountToAdd = 0;

        #region Adding to slots with same items
        var availableSlotsWithSameItem = _slots
            .Where(slot => !slot.IsEmpty && slot.Item.ID == item.ID && !slot.IsFull).ToList();

        if (availableSlotsWithSameItem.Count != 0)
        {
            availableSlotsWithSameItem.ForEach(slot => availableAmount += slot.Capacity - slot.Amount);

            if (availableAmount < amount)
            {
                newAmountToAdd = availableAmount;
                amount -= availableAmount;
            }
            else
            {
                newAmountToAdd = amount;
                amount -= newAmountToAdd;
            }
            AddToSlots(availableSlotsWithSameItem, item, newAmountToAdd);
            Debug.Log($"Added item {item.Name} with amount {newAmountToAdd}");

            if (amount == 0)
                return true;
        }
        #endregion

        #region Adding to empty slots
        if (AddToEmptySlots(item, amount) == 0)
            return true;
        #endregion

        //if inventory becomes full, return false
        Debug.Log($"Failed to add item {item.Name} with amount {amount}");
        return false;
    }

    public int AddToEmptySlots(IInventoryItem item, int amount) 
    {
        int availableAmount = 0, newAmountToAdd = 0;

        var emptySlots = _slots.Where(slot => slot.IsEmpty).ToList();

        if (emptySlots.Count != 0)
        {
            availableAmount = 0; newAmountToAdd = 0;
            emptySlots.ForEach(slot => availableAmount += item.MaxAmountInSlot);

            if (availableAmount < amount)
            {
                newAmountToAdd = availableAmount;
                amount -= availableAmount;
            }
            else
            {
                newAmountToAdd = amount;
                amount -= newAmountToAdd;
            }
            AddToSlots(emptySlots, item, newAmountToAdd);
            Debug.Log($"Added item {item.Name} with amount {newAmountToAdd}");

            return amount;
        }

        return -1;
    }

    public void AddToSlots(List<InventorySlot> slots, IInventoryItem item, int amountToAdd)
    {
        foreach (var slot in slots)
        {
            int individualAddAmount = 0;
            int availableAmount = slot.IsEmpty ? item.MaxAmountInSlot : slot.Capacity - slot.Amount;
            individualAddAmount = availableAmount < amountToAdd ? availableAmount : amountToAdd;

            if (slot.IsEmpty)
            {
                IInventoryItem clonedItem = item.Clone();
                clonedItem.Amount = individualAddAmount;
                slot.SetItem(clonedItem);
            }
            else
            {
                slot.IncreaseAmount(individualAddAmount);
            }
            amountToAdd -= individualAddAmount;

            if (amountToAdd == 0)
                break;
        }
    }

    public bool TryRemove(IInventoryItem item, int amountToRemove = 1)
    {
        var slotsWithItem = _slots.FindAll(slot => !slot.IsEmpty && slot.Item.ID == item.ID);

        if (slotsWithItem == null)
        {
            Debug.Log($"Failed to remove item {item.Name} with amount {amountToRemove}");
            return false;
        }

        int totalAmount = 0;
        slotsWithItem.ForEach(slot => totalAmount += slot.Amount);

        if (totalAmount < amountToRemove)
        {
            Debug.Log($"Failed to remove item {item.Name} with amount {amountToRemove}");
            return false;
        }

        for (int i = slotsWithItem.Count - 1; i >= 0; i--)
        {
            int individualRemoveAmount = 0, availableAmount = slotsWithItem[i].Amount;
            individualRemoveAmount = availableAmount < amountToRemove ? availableAmount : amountToRemove;

            slotsWithItem[i].DecreaseAmount(individualRemoveAmount);
            Debug.Log($"Removed item {item.Name} with amount {individualRemoveAmount}");
            amountToRemove -= individualRemoveAmount;

            if (slotsWithItem[i].Amount == 0)
                slotsWithItem[i].Clear();

            if (amountToRemove == 0)
                break;
        }
        return true;
    }

    public void TransferFromSlotToSlot(IInventorySlot from, IInventorySlot to)
    {
        if (from.IsEmpty)
            return;

        if (to.IsFull && from.Item.ID == to.Item.ID)
            return;

        #region Transfering to empty slot
        if (to.IsEmpty)
        {
            to.SetItem(from.Item);
            from.Clear();
            return;
        }
        #endregion

        #region Transfering if slots have different types of objects in them
        if (from.Item.ID != to.Item.ID)
        {
            IInventoryItem tempItem = from.Item;
            from.Clear();
            from.SetItem(to.Item);

            to.Clear();
            to.SetItem(tempItem);
            return;
        }
        #endregion

        #region Transfering if slots have same item type
        int availableAmount = to.Capacity - to.Amount;

        if (availableAmount < from.Amount)
        {
            to.IncreaseAmount(availableAmount);
            from.DecreaseAmount(availableAmount);
        }
        else
        {
            to.IncreaseAmount(from.Amount);
            from.Clear();
        }
        #endregion
    }
}
