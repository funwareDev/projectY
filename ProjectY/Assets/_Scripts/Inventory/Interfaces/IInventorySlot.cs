using System;

public interface IInventorySlot
{
    bool IsEmpty { get; }
    bool IsFull { get; }

    IInventoryItem Item { get; }
    int Amount { get; }
    int Capacity { get; }

    public event Action SlotChanged;

    void SetItem(IInventoryItem item);
    public void IncreaseAmount(int amount);
    public void DecreaseAmount(int amount);
    void Clear();
}
