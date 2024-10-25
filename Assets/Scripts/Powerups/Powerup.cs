using UnityEngine;

// Class for managing power-up counts
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
    // Declare instances of rune for counting power-ups taken
    private static rune health = new rune(0);
    private static rune damage = new rune(0);
    private static rune speed = new rune(0);

    public enum PowerUpType
    {
        Health,
        Damage,
        Speed
    }

    [SerializeField] private PowerUpType powerUpType; // The type of power-up
    private float _spawnProbability; // Spawn probability for the power-up

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

    // OnTriggerEnter2D method to handle power-up collection
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (powerUpType)
            {
                case PowerUpType.Health:
                    health.SetTaken(health.GetTaken() + 1); // Increment health power-ups taken
                    // Implement health increase logic here
                    Debug.Log(health.GetTaken());
                    break;

                case PowerUpType.Damage:
                    damage.SetTaken(damage.GetTaken() + 1); // Increment damage power-ups taken
                    // Implement damage increase logic here
                    Debug.Log(damage.GetTaken());
                    break;

                case PowerUpType.Speed:
                    speed.SetTaken(speed.GetTaken() + 1); // Increment speed power-ups taken
                    // Implement speed increase logic here
                    break;
            }

            // Destroy the power-up after it has been collected
            Destroy(gameObject);
        }
    }
}
