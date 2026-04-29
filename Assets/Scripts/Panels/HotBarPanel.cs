using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotBarPanel : BasePanel
{
    public List<InventorySlots> hotBarSlots;
    public BuildingSystem buildingSystem;

    public override void Start()
    {
        base.Start();
        buildingSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<BuildingSystem>();
    }

    public void AddSlot(InventorySlots slot)
    {
        hotBarSlots.Add(slot);
        slot.transform.SetParent(transform);
        slot.gameObject.AddComponent<Button>().onClick.AddListener(() => buildingSystem.SetCurrentItem(slot.item));
    }
}
