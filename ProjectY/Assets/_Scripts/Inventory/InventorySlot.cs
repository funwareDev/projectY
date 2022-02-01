using System;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : IInventorySlot
{
    public bool IsEmpty => Item == null || Amount == 0;
    public bool IsFull => !IsEmpty && Amount == Item.MaxAmountInSlot;

    public IInventoryItem Item { get; private set; }

    public int Amount => Item.Amount;
    public int Capacity => Item.MaxAmountInSlot;

    public event Action SlotChanged;

    public void SetItem(IInventoryItem item)
    {
        if (!IsEmpty)
            return;

        Item = item;
        SlotChanged?.Invoke();
    }

    public void IncreaseAmount(int amount)
    {
        Item.Amount += amount;
        SlotChanged?.Invoke();
    }

    public void DecreaseAmount(int amount)
    {
        Item.Amount -= amount;
        SlotChanged?.Invoke();
    }

    public void Clear()
    {
        if (IsEmpty)
            return;

        Item = null;
        SlotChanged?.Invoke();
    }
}
