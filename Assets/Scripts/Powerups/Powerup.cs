using UnityEngine;

// Regulus Written
public class rune
{
    private int _taken;

    public rune(int taken)
    {
        this._taken = taken;
    }

    public int GetTaken()
    {
        return this._taken;
    }

    public void SetTaken(int newTaken)
    {
        this._taken = newTaken;
    }
}

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
    private static rune health = new rune(0);
    private static rune damage = new rune(0);

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
                    health.SetTaken(health.GetTaken() + 1); // Increment health power-ups taken
                    Debug.Log("Health Power-Ups Taken: " + health.GetTaken());
                    // Implement health increase logic here
                    break;

                case PowerUpType.Damage:
                    damage.SetTaken(damage.GetTaken() + 1); // Increment damage power-ups taken
                    Debug.Log("Damage Power-Ups Taken: " + damage.GetTaken());
                    // Implement damage increase logic here
                    break;

                case PowerUpType.Speed:
                    // Implement speed increase logic here
                    Debug.Log("Speed Power-Up Collected");
                    break;
            }

            // Destroy the power-up after it has been collected
            Destroy(gameObject);
        }
    }
}
