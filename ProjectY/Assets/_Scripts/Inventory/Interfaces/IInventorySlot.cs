using System;

public interface IInventorySlot
{
    bool IsEmpty { get; }
    bool IsFull { get; }

    IInventoryItem Item { get; }
    int Amount { get; }
    int Capacity { get; }

    public event Action SlotChanged;

    void SetItem(IInventoryItem item, int amount);
    void Clear();
}
