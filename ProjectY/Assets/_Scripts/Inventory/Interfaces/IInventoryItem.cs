using UnityEngine;

public interface IInventoryItem
{
    int ID { get; }
    string Name { get; }
    int Amount { get; set; }
    int MaxAmountInSlot { get; }

    InventoryItemInfo ItemInfo { get; }
    IInventoryItem Clone();
}
