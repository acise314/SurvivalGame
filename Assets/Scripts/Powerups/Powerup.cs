using UnityEngine;

public class Powerup : MonoBehaviour
{
    public enum PowerupType { Health, Damage }
    public PowerupType powerupType;

    private int healthAmount = 5;
    private float damageAmount = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                ApplyPowerup(player);
                Destroy(gameObject); // Destroy powerup after collection
            }
        }
    }

    private void ApplyPowerup(Player player)
    {
        switch (powerupType)
        {
            case PowerupType.Health:
                player.AddHealth(healthAmount);
                break;
            case PowerupType.Damage:
                player.AddDamage(damageAmount);
                break;
        }
    }
}
