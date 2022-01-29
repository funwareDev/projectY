using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

class UIInventoryItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private Text _amountText;

    private IInventorySlot _inventorySlot;

    private Canvas _canvas;
    private CanvasGroup _canvasGroup;
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Init(IInventorySlot inventorySlot)
    {
        _inventorySlot = inventorySlot;
        _inventorySlot.SlotChanged += Refresh;
        Refresh();
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
        transform.localPosition = Vector3.zero;
        _canvasGroup.blocksRaycasts = true;
    }

    public void Refresh()
    {
        if (_inventorySlot.IsEmpty)
        {
            //_iconImage.gameObject.SetActive(false);
            _amountText.text = "0";
            return;
        }
        else
        {
            _iconImage.gameObject.SetActive(true);
        }

        _iconImage.sprite = _inventorySlot.Item.ItemInfo.Icon;
        _amountText.text = _inventorySlot.Amount.ToString();
    }
}

