using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for holding abstract inventory instance, for pickuping and dropping items.
/// </summary>
public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int _capacity;
    [SerializeField] private UIInventory _uiInventory;
    [SerializeField] private Camera _camera;

    [SerializeField] private ItemPresenter _itemPresenterTemplate;
    [SerializeField] private float _dropForce;
    [SerializeField] private Transform _itemDropper;


    public IInventory Inventory { get; private set; }

    private void Awake()
    {
        Inventory = new Inventory(_capacity);
        _uiInventory = FindObjectOfType<UIInventory>();

        _uiInventory.Init(Inventory);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ItemPresenter>(out ItemPresenter itemPresenter))
            TryPickUp(itemPresenter);
    }

    private void TryPickUp(ItemPresenter itemPresenter)
    {
        IInventoryItem itemToAdd = itemPresenter.InventoryItem;

        if (itemToAdd == null)
            return;

        Inventory.TryAdd(itemToAdd, itemToAdd.Amount);
        Destroy(itemPresenter.gameObject);
    }

    public void DropItem(IInventorySlot slot)
    {
        Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseDirection = mousePosition - new Vector2(transform.position.x, transform.position.y);
        mouseDirection = new Vector3(mouseDirection.x, Math.Abs(mouseDirection.y));
        
        Vector2 playerRotation = mouseDirection.normalized;
        transform.rotation = Math.Round(playerRotation.x) == -1.0f ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.Euler(0f, 0f, 0f); //shit, has to be rewritten

        var itemPresenter = Instantiate(_itemPresenterTemplate, _itemDropper.position, Quaternion.identity);
        itemPresenter.GetComponent<Rigidbody2D>().AddForce(mousePosition * _dropForce);
        itemPresenter.Init(slot.Item);
        slot.Clear();
    }

}
