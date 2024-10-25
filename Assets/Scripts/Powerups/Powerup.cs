using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType
    {
        Health,
        Damage,
        Speed
    }

    [SerializeField] private PowerUpType powerUpType; // The type of power-up
    private float _spawnProbability; // Spawn probability for the power-up

    // Encapsulated properties for power-ups taken
    private static rune healthRune = new rune("Health", 0, 5);
    private static rune damageRune = new rune("Damage", 0, 5);
    private static rune speedRune = new rune("Speed", 0, 1);

    // Constructor to set spawn probability
    public PowerUp(float spawnProbability)
    {
        SetSpawnProbability(spawnProbability);
    }

    // Getter and Setter for spawn probability
    public float GetSpawnProbability()
    {
        return _spawnProbability;
    }

    public void SetSpawnProbability(float spawnProbability)
    {
        _spawnProbability = spawnProbability;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (powerUpType)
            {
                case PowerUpType.Health:
                    healthRune.SetTaken(healthRune.GetTaken() + 1);
                    Debug.Log($"Health Power-Up Taken: {healthRune.GetTaken()}");
                    other.GetComponent<Player>().changeHealth(healthRune.GetIncrease()); // Add health
                    break;

                case PowerUpType.Damage:
                    damageRune.SetTaken(damageRune.GetTaken() + 1);
                    Debug.Log($"Damage Power-Up Taken: {damageRune.GetTaken()}");
                    other.GetComponent<Player>().changeDamage(damageRune.GetIncrease()); // Add damage
                    break;

                case PowerUpType.Speed:
                    speedRune.SetTaken(speedRune.GetTaken() + 1);
                    Debug.Log($"Speed Power-Up Taken: {speedRune.GetTaken()}");
                    other.GetComponent<Player>().changeSpeed(speedRune.GetIncrease()); // Add speed
                    break;
            }

            // Destroy the power-up after it has been collected
            Destroy(gameObject);
        }
    }
}
