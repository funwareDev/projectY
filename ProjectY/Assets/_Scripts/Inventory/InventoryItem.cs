class InventoryItem : IInventoryItem
{
    public int ID => ItemInfo.ID;
    public string Name => ItemInfo.Name;
    public int Amount { get; set; }
    public int MaxAmountInSlot => ItemInfo.MaxAmountInSlot;
    public InventoryItemInfo ItemInfo { get; set; }

    public InventoryItem(InventoryItemInfo itemInfo)
    {
        ItemInfo = itemInfo;
    }

    public IInventoryItem Clone()
    {
        return new InventoryItem(ItemInfo);
    }
}

