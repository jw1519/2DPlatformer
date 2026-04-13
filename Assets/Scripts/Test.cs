using UnityEngine;

public class Test : MonoBehaviour
{
    public BaseItem item;

    private void Start()
    {
        InventoryPanel invent = GetComponent<UIManager>().registeredPanels.Find(panel => panel.name == "InventoryPanel").GetComponent<InventoryPanel>();
        invent.AddItem(item);
    }
}
