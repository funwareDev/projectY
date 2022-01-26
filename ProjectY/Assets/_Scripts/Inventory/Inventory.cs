using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<AssetItem> _items;
    [SerializeField] private InventoryCell _inventoryCellTemplate;
    [SerializeField] private Transform _container;


    private void OnEnable()
    {
        Render();
    }

    private void Render()
    {
        foreach (AssetItem item in _items)
        {
            var cell = Instantiate(_inventoryCellTemplate, _container);
        }
    }
}
