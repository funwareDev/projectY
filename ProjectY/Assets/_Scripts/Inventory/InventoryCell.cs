using UnityEngine;
using UnityEngine.UI;

class InventoryCell
{
    [SerializeField] private Text _text;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void Render(IItem item)
    {
        _text.text = item.Name;
        _spriteRenderer.sprite = item.Icon;
    }
}
