using UnityEngine;

// Base PowerUp class
public class PowerUp : MonoBehaviour
{
    private PowerUpEffect _effect; // Stores the effect of the power-up

    // Constructor to set the effect
    public void Initialize(PowerUpEffect effect)
    {
        _effect = effect;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            // Apply the power-up effect to the player
            _effect.ApplyEffect(player);

            // Destroy the power-up after it's used
            Destroy(gameObject);
        }
    }
}

// Interface for power-up effects
public interface PowerUpEffect
{
    void ApplyEffect(Player player);
}

// HealthPowerUp class
public class HealthPowerUp : PowerUpEffect
{
    private int _healthAmount;

    public HealthPowerUp(int healthAmount)
    {
        _healthAmount = healthAmount;
    }

    public void ApplyEffect(Player player)
    {
        player.changeHealth(_healthAmount);
        Debug.Log("Health increased by " + _healthAmount);
    }
}

// DamagePowerUp class
public class DamagePowerUp : PowerUpEffect
{
    private float _damageAmount;

    public DamagePowerUp(float damageAmount)
    {
        _damageAmount = damageAmount;
    }

    public void ApplyEffect(Player player)
    {
        // Convert player damage to float before adding _damageAmount
        float currentDamage = (float)player.GetDamage();
        player.changeDamage(currentDamage + _damageAmount);
        Debug.Log("Damage increased by " + _damageAmount);
    }
}
