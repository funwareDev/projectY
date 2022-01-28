using UnityEngine;

public interface IInventoryItem
{
    int ID { get; }
    string Name { get; }
    int MaxAmountInSlot { get; }

    InventoryItemInfo ItemInfo { get; }
}
