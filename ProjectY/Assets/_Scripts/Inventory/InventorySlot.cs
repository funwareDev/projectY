using System;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : IInventorySlot
{
    public bool IsEmpty => Item == null || Amount == 0;
    public bool IsFull => Amount == Item.MaxAmountInSlot;

    public IInventoryItem Item { get; private set; }

    public int Amount { get; private set; }
    public int Capacity => Item.MaxAmountInSlot;

    public event Action SlotChanged;

    public void SetItem(IInventoryItem item, int amount)
    {
        if (!IsEmpty)
            return;

        Item = item;
        Amount = amount;
        SlotChanged?.Invoke();
    }

    public void IncreaseAmount(int amount)
    {
        Amount += amount;
        SlotChanged?.Invoke();
    }

    public void DecreaseAmount(int amount)
    {
        Amount -= amount;
        SlotChanged?.Invoke();
    }

    public void Clear()
    {
        if (IsEmpty)
            return;

        Item = null;
        Amount = 0;
        SlotChanged?.Invoke();
    }
}
