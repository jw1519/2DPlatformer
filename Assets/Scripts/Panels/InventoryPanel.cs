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
    public void SwapSlots(int a, int b)
    {
        if (a == b) return; // No need to swap if the same slot is selected
        if (a < 0 || a >= itemSlots.Count || b < 0 || b >= itemSlots.Count)
        {
            Debug.Log("Invalid slot indices for swapping!");
            return;
        }
        InventorySlots temp = itemSlots[a];
        itemSlots[a] = itemSlots[b];
        itemSlots[b] = temp;

        itemSlots[a].UpdateQuantity(itemSlots[a].quantity); // Update the UI after swapping
        itemSlots[b].UpdateQuantity(itemSlots[b].quantity); // Update the UI after swapping
    }
}
