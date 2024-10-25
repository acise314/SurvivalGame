using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Type { Health, Damage }
    public Type powerUpType; // Set this in the Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            if (powerUpType == Type.Health)
            {
                player.changeHealth(5); // Increase health by 5
            }
            else if (powerUpType == Type.Damage)
            {
                player.changeDamage((float)player.GetDamage() + 5); // Cast to float for damage
            }
            Destroy(gameObject); // Remove the power-up
        }
    }
}
