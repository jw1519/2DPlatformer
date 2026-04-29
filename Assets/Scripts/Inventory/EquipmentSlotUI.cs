using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlotUI : MonoBehaviour, IDropHandler
{
    EquipmentPanel equipmentPanel;
    Image itemImage;
    Image dragIcon;

    public EquipmentSlotType slotType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        equipmentPanel = UIManager.Instance.registeredPanels.Find(p => p.GetComponent<EquipmentPanel>() != null)?.GetComponent<EquipmentPanel>();
        itemImage = GetComponent<Image>();
        dragIcon = transform.GetChild(0).GetComponent<Image>();
    }
    public void SetItem(BaseItem item)
    {
        if (item != null && item.itemSprite != null)
        {
            itemImage.sprite = item.itemSprite;
            dragIcon.sprite = item.itemSprite;
            equipmentPanel.EquipItem(item);
        }
        else
        {
            itemImage.sprite = null;
            dragIcon.sprite = null;
            equipmentPanel.EquipItem(null);
        }
    }
    public void ClearSlot()
    {
        SetItem(null);
    }

    public void OnDrop(PointerEventData eventData)
    {

    }

    public enum EquipmentSlotType
    {
        Head,
        Body,
        Legs,
        Boots,
        Weapon,
    }
}
