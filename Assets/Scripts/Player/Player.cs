using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int damage;

    PlayerStatsPanel playerStatsPanel;
    private void Start()
    {
        health = maxHealth;
        playerStatsPanel = UIManager.Instance.registeredPanels.Find(panel => panel is PlayerStatsPanel) as PlayerStatsPanel;
        if (playerStatsPanel != null)
        {
            playerStatsPanel.SetMaxHealth(maxHealth);
            playerStatsPanel.UpdateHealth(health);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        playerStatsPanel.UpdateHealth(health);
    }
    private void Die()
    {
        // Handle player death (e.g., play animation, disable controls, etc.)
        
    }
}
