using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class InventoryItemInfo : ScriptableObject
{
    public int ID => _id;
    public int MaxAmountInSlot => _maxAmountInSlot;
    public string Name => _name;
    public Sprite Icon => _icon;

    [SerializeField] private int _id;
    [SerializeField] private int _maxAmountInSlot;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
}
