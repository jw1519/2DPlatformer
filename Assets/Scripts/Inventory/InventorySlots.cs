using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlots : MonoBehaviour, IDropHandler
{
    public BaseItem item;
    public int quantity;

    public Image itemImage;
    public TextMeshProUGUI quantityText;
    private void Awake()
    {
        ClearSlot();
    }

    public void UpdateQuantity(int amount)
    {
        quantity += amount;
        quantityText.text = quantity.ToString();
        if (quantity <= 0)
        {
            ClearSlot();
        }
    }
    public void ClearSlot()
    {
        item = null;
        quantity = 0;
        quantityText.text = "";
        itemImage.sprite = null;
    }
    public void OnDrop(PointerEventData eventData) //isnt being called
    {
        Debug.Log("OnDrop called on " + gameObject.name);
        if (transform.childCount == 0)
        {
            InventorySlots newSlot = eventData.pointerEnter.GetComponent<InventorySlots>();
            if (newSlot.item == null)
            {
                newSlot.item = item;
                newSlot.UpdateQuantity(quantity);
                ClearSlot();
            }
            else
            {
                // Swap items

                //store new slot item and quantity in temp variables
                BaseItem tempItem = newSlot.item;
                int tempQuantity = newSlot.quantity;

                //store this slot item and quantity in new slot
                BaseItem currentItem = item;
                int currentQuantity = quantity;

                if (tempItem != null)
                {
                    ClearSlot();
                    item = tempItem;
                    UpdateQuantity(tempQuantity);
                }
                if (currentItem != null)
                {
                    newSlot.ClearSlot();
                    newSlot.item = currentItem;
                    newSlot.UpdateQuantity(currentQuantity);
                }
            }
        }
    }

}
