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
    private static int _healthPowerUpsTaken;
    private static int _damagePowerUpsTaken;
    private static int _speedPowerUpsTaken;

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

    // Properties for accessing the power-up counts
    public int GetHealthPowerUpsTaken()
    {
        return _healthPowerUpsTaken;
    }

    protected void SetHealthPowerUpsTaken(int value)
    {
        _healthPowerUpsTaken = value;
    }

    public int GetDamagePowerUpsTaken()
    {
        return _damagePowerUpsTaken;
    }

    protected void SetDamagePowerUpsTaken(int value)
    {
        _damagePowerUpsTaken = value;
    }

    public int GetSpeedPowerUpsTaken()
    {
        return _speedPowerUpsTaken;
    }

    protected void SetSpeedPowerUpsTaken(int value)
    {
        _speedPowerUpsTaken = value;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (powerUpType)
            {
                case PowerUpType.Health:
                    SetHealthPowerUpsTaken(GetHealthPowerUpsTaken() + 1);
                    // Implement health increase logic here
                    break;

                case PowerUpType.Damage:
                    SetDamagePowerUpsTaken(GetDamagePowerUpsTaken() + 1);
                    // Implement damage increase logic here
                    break;

                case PowerUpType.Speed:
                    SetSpeedPowerUpsTaken(GetSpeedPowerUpsTaken() + 1);
                    // Implement speed increase logic here
                    break;
            }

            // Destroy the power-up after it has been collected
            Destroy(gameObject);
        }
    }
}
