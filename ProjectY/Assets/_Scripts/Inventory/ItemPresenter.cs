using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPresenter : MonoBehaviour
{
    public int Amount => InventoryItem.Amount;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    public IInventoryItem InventoryItem { get; private set; }

    public void Init(IInventoryItem inventoryItem)
    {
        InventoryItem = inventoryItem;
        _spriteRenderer.sprite = InventoryItem.ItemInfo.Icon;
    }
}
