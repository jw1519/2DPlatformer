using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class BaseItem : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;
    public ItemType itemType;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4); // Default range for actions

    public virtual void UseItem()
    {
        Debug.Log($"Using {itemName}");
    }

}
public enum ItemType
{
    Weapon,
    Armor,
    Consumable,
    QuestItem,
    Placeable,
    Miscellaneous
}
public enum ActionType
{
    Dig,
    Mine
}
