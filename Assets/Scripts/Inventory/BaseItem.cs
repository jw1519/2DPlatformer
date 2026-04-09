using UnityEngine;

public class BaseItem : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;
    public ItemType itemType;

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
