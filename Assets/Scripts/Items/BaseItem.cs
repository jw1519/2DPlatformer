using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class BaseItem : ScriptableObject
{
    public string itemName;
    public string description;
    public TileBase tile;
    public Sprite itemSprite;
    public ItemType itemType;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4); // Default range for actions
    public int power = 1;
    public virtual void UseItem()
    {
        Debug.Log($"Using {itemName}");
    }

}
public enum ItemType
{
    Weapon,
    Armor,
    Tool,
    Consumable,
    QuestItem,
    BuildingBlock,
    Miscellaneous
}
public enum ActionType
{
    Dig,
    Mine
}
