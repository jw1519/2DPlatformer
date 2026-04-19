using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, ITakeDamage
{
    public string enemyName;
    public int maxHealth;
    public int currentHealth;
    public int damage;
    public List<BaseItem> lootTable;
    public GameObject lootPrefab;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        // Handle enemy death (e.g., play animation, drop loot, etc.)
        if (lootPrefab != null && lootTable.Count > 0)
        {
            BaseItem lootItem = lootTable[Random.Range(0, lootTable.Count)];
            GameObject loot = Instantiate(lootPrefab, transform.position, Quaternion.identity);
            loot.GetComponent<ItemDrop>().SetItem(lootItem);
        }
        Destroy(gameObject);
    }
}
