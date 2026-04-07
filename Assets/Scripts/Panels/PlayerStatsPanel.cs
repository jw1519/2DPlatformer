using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsPanel : BasePanel
{
    public Slider healthBar;
    public Slider HungerBar;

    public void SetMaxHealth(int max)
    {
        healthBar.maxValue = max;
    }

    public void UpdateHealth(float health)
    {
        healthBar.value = health;
    }
    public void UpdateHunger(float hunger)
    {
        HungerBar.value = hunger;
    }
}
