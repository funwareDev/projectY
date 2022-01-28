using System;

public interface IInventory
{
    int Capacity { get; }
    bool IsFull { get; }

    IInventoryItem GetItem(int itemID);
    IInventoryItem[] GetAllItems();
    IInventoryItem[] GetAllItemsOfType(int itemID);
    int GetItemAmount(int itemID);
    IInventorySlot[] GetAllSlots();

    bool TryAdd(IInventoryItem item, int amount);
    bool TryRemove(IInventoryItem item, int amount = 1);
    bool HasItem(int itemID, out IInventoryItem item);
}
