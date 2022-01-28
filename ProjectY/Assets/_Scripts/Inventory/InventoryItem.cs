class InventoryItem : IInventoryItem
{
    public int ID => ItemInfo.ID;

    public string Name => ItemInfo.Name;

    public int MaxAmountInSlot => ItemInfo.MaxAmountInSlot;

    public InventoryItemInfo ItemInfo { get; set; }

    public InventoryItem(InventoryItemInfo itemInfo)
    {
        ItemInfo = itemInfo;
    }
}

