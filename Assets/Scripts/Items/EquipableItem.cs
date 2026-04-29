using UnityEngine;

public class EquipableItem : BaseItem, IEquipable
{
    public int healthBonus;
    public int damageBonus;
    public int defenseBonus;

    public void Equip(GameObject player)
    {
        throw new System.NotImplementedException();
    }

    public void UnEquip(GameObject player)
    {
        throw new System.NotImplementedException();
    }
}
