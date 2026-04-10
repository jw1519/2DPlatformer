using System.Collections.Generic;
using UnityEngine;

public class TestInvent : MonoBehaviour
{
    public List<BaseItem> items;

    public void button()
    {
        InventoryPanel panel = GetComponent<UIManager>().registeredPanels.Find(print => print.name == "InventoryPanel").GetComponent<InventoryPanel>();
        panel.AddItem(items[0], 5);
        panel.AddItem(items[1], 3);
    }
}
