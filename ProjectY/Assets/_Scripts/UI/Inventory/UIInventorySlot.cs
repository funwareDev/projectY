using System;
using UnityEngine;
using UnityEngine.EventSystems;

class UIInventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;
        otherItemTransform.SetParent(transform);
        otherItemTransform.position = Vector3.zero;
    }
}
