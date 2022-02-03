using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIInventoryItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private Text _amountText;

    public event Action<UIInventorySlot> ItemDrop;
    public Image IconImage => _iconImage;
    public Text AmountText => _amountText;

    public Canvas _canvas;
    private CanvasGroup _canvasGroup;
    private RectTransform _rectTransform;
    
    private UIInventory _uiInventory;
    private UIInventorySlot _uiInventorySlot;

    public bool IsDivided = false;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();

        _uiInventory = GetComponentInParent<UIInventory>();
        _uiInventorySlot = GetComponentInParent<UIInventorySlot>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var slotTransform = _rectTransform.parent.transform;
        slotTransform.SetAsLastSibling();
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!In((RectTransform)_uiInventory.transform))
            ItemDrop?.Invoke(_uiInventorySlot);

        transform.localPosition = Vector3.zero;
        _canvasGroup.blocksRaycasts = true;
    }

    private bool In(RectTransform originalParent)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(originalParent, transform.position);
    }
}

