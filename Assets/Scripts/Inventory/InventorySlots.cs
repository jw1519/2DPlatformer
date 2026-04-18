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
    public Image dragIcon;
    public bool isHotBarSlot = false;
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
    public void SetItem(BaseItem newItem)
    {
        item = newItem;
        if (item.itemSprite != null)
        {
            itemImage.sprite = item.itemSprite;
            dragIcon.sprite = item.itemSprite;
        }
    }
    public void ClearSlot()
    {
        item = null;
        quantity = 0;
        quantityText.text = "";
        itemImage.sprite = null;
        dragIcon.sprite = null;
    }
    public void OnDrop(PointerEventData eventData)
    {
        InventorySlots newSlot = UIManager.Instance.currentDragSlot;
        if (newSlot == null) return;

        if (newSlot.item == null)
        {
            newSlot.SetItem(item);
            newSlot.UpdateQuantity(quantity);
            ClearSlot();
        }
        else
        {
            UIManager.Instance.registeredPanels.Find(p => p.GetComponent<InventoryPanel>() != null)?.GetComponent<InventoryPanel>().SwapSlots(this, newSlot);
        }
    }

}
