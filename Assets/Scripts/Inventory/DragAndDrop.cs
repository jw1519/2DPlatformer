using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    InventorySlots thisSlot;
    private void Start()
    {
        thisSlot = GetComponentInParent<InventorySlots>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //if mouse is over another inventory slot, swap items or move item if new slot is empty

        Debug.Log(eventData.pointerEnter.GetComponent<InventorySlots>()); // is null
        if (eventData.pointerEnter != null && eventData.pointerEnter.GetComponent<InventorySlots>() != null) //not going in the method
        {
            InventorySlots newSlot = eventData.pointerEnter.GetComponent<InventorySlots>();
            if (newSlot.item == null)
            {
                newSlot.item = thisSlot.item;
                newSlot.UpdateQuantity(thisSlot.quantity);
                thisSlot.ClearSlot();
            }
            else
            {
                // Swap items

                //store new slot item and quantity in temp variables
                BaseItem tempItem = newSlot.item;
                int tempQuantity = newSlot.quantity;

                //store this slot item and quantity in new slot
                BaseItem currentItem = thisSlot.item;
                int currentQuantity = thisSlot.quantity;

                if (tempItem != null)
                {
                    thisSlot.ClearSlot();
                    thisSlot.item = tempItem;
                    thisSlot.UpdateQuantity(tempQuantity);
                }
                if (currentItem != null)
                {
                    newSlot.ClearSlot();
                    newSlot.item = currentItem;
                    newSlot.UpdateQuantity(currentQuantity);
                }
            }
        }
        transform.SetParent(thisSlot.transform);
        transform.localPosition = Vector3.zero;
    }
}
