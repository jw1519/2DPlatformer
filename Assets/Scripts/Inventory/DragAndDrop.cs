using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    InventorySlots thisSlot;
    Transform dragIcon;
    private void Start()
    {
        thisSlot = GetComponent<InventorySlots>();
        dragIcon = thisSlot.dragIcon.transform;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (thisSlot.item == null) return; // Don't start dragging if there's no item in the slot
        dragIcon.SetParent(transform.root);
        dragIcon.SetAsLastSibling();
        dragIcon.gameObject.SetActive(true);
        UIManager.Instance.currentDragSlot = thisSlot; // Set the current dragging slot in UIManager
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (thisSlot.item == null) { return; }
        dragIcon.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragIcon.SetParent(thisSlot.transform);
        dragIcon.localPosition = Vector3.zero;
        dragIcon.gameObject.SetActive(false);
    }
}
