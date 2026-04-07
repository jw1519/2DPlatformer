using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int damage;
    private void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        // Handle player death (e.g., play animation, disable controls, etc.)
        
    }
}
