using UnityEngine;

public class EquipmentPanel : BasePanel
{
    public InventorySlots headSlot;
    public InventorySlots bodySlot;
    public InventorySlots legsSlot;
    public InventorySlots weaponSlot;
    public InventorySlots shieldSlot;

    public void EquipItem(BaseItem item)
    {
        switch (item.itemType)
        {
            case (ItemType)EquipmentSlotUI.EquipmentSlotType.Head:
                headSlot.SetItem(item);
                break;
            case (ItemType)EquipmentSlotUI.EquipmentSlotType.Body:
                bodySlot.SetItem(item);
                break;
            case (ItemType)EquipmentSlotUI.EquipmentSlotType.Legs:
                legsSlot.SetItem(item);
                break;
            case (ItemType)EquipmentSlotUI.EquipmentSlotType.Weapon:
                weaponSlot.SetItem(item);
                break;
        }
    }

}
