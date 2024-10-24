using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject healthPowerupPrefab;
    public GameObject damagePowerupPrefab;
    public Transform playerTransform;
    private float spawnRadius = 5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnRandomPowerup), 5f, 10f); // Spawns every 10 seconds after 5 seconds
    }

    private void SpawnRandomPowerup()
    {
        Vector2 spawnPosition = (Vector2)playerTransform.position + Random.insideUnitCircle * spawnRadius;
        int powerupType = Random.Range(0, 2); // 0 for Health, 1 for Damage

        if (powerupType == 0)
        {
            Instantiate(healthPowerupPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(damagePowerupPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
