using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : BasePanel
{
    public List<InventorySlots> itemSlots;

    public GameObject itemSlotPrefab;
    public int maxSlots = 20;
    public int amountSlotsInRow = 6;

    public override void Start()
    {
        base.Start();
        for (int i = 0; i < maxSlots; i++)
        {
            InventorySlots instance = Instantiate(itemSlotPrefab, transform).GetComponent<InventorySlots>();
            instance.name = "Slot " + (i + 1);
            itemSlots.Add(instance);
            if (i < amountSlotsInRow)
            {
                instance.transform.SetParent(UIManager.Instance.registeredPanels.Find(p => p.name == "HotBar").GetComponent<Transform>());
            }
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
                inventorySlots.SetItem(item);
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
            Debug.Log(slot.item);
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
    public void SwapSlots(InventorySlots slotA, InventorySlots slotB)
    {
        if (slotA == null || slotB == null) return; // Ensure both slots are valid
        if (slotA.item == null && slotB.item == null) return; // No need to swap if both slots are empty
        if (slotA == slotB) return; // No need to swap if the same slot is selected

        if (slotA.item == null)
        {
            slotA.ClearSlot();
            slotA.SetItem(slotB.item);
            slotA.UpdateQuantity(slotB.quantity);
            slotB.ClearSlot();
        }
        else if (slotB.item == null)
        {
            slotB.ClearSlot();
            slotB.SetItem(slotA.item);
            slotB.UpdateQuantity(slotA.quantity);
            slotA.ClearSlot();
        }
        else
        {
            BaseItem tempItem = slotA.item;
            int tempQuantity = slotA.quantity;

            slotA.ClearSlot();
            slotA.SetItem(slotB.item);
            slotA.UpdateQuantity(slotB.quantity);

            slotB.ClearSlot();
            slotB.SetItem(tempItem);
            slotB.UpdateQuantity(tempQuantity);
        }
    }
}
