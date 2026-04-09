using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : BasePanel
{
    public List<BaseItem> items;
    public List<InventorySlots> itemSlots;

    public GameObject itemSlotPrefab;
    public int maxSlots = 20;

    private void Awake()
    {
        for (int i = 0; i < maxSlots; i++)
        {
            Instantiate(itemSlotPrefab, transform);
        }
    }

    public void AddItem(BaseItem item, int amount = 1)
    {
        InventorySlots inventorySlots = GetSlotWithItem(item);
        if (inventorySlots != null)
        {
            inventorySlots.UpdateQuantity(amount);
            return;
        }
        else
        {
            inventorySlots = GetEmptySlot();
            if (inventorySlots != null)
            {
                inventorySlots.item = item;
                inventorySlots.UpdateQuantity(amount);
            }
            else
            {
                Debug.Log("No empty slots available!");
                return;
            }
        }
    }
    public void RemoveItem(BaseItem item, int amount = 1)
    {
        InventorySlots inventorySlots = GetSlotWithItem(item);
        if (inventorySlots != null)
        {
            inventorySlots.UpdateQuantity(-amount);
            if (inventorySlots.quantity <= 0)
            {
                inventorySlots.ClearSlot();
            }
        }
        else
        {
            Debug.Log("Item not found in inventory!");
            return;
        }
    }
    public InventorySlots GetEmptySlot()
    {
        foreach (var slot in itemSlots)
        {
            if (slot.item == null)
            {
                return slot;
            }
        }
        return null;
    }
    public InventorySlots GetSlotWithItem(BaseItem item)
    {
        foreach (var slot in itemSlots)
        {
            if (slot.item == item)
            {
                return slot;
            }
        }
        return null;
    }
}
