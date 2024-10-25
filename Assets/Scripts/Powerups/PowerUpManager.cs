using System.Collections;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject healthPowerUpPrefab;
    public GameObject damagePowerUpPrefab;
    public GameObject speedPowerUpPrefab;

    public float spawnRadius = 10f; // Distance from player to spawn power-ups
    public float spawnInterval = 5f; // Time between spawns

    private void Start()
    {
        StartCoroutine(SpawnPowerUps());
    }

    private IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // Randomly choose a power-up type to spawn
            GameObject powerUpPrefab = ChooseRandomPowerUp();
            Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

            Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private GameObject ChooseRandomPowerUp()
    {
        float healthSpawnChance = 0.45f; // 45% chance for health
        float damageSpawnChance = 0.45f; // 45% chance for damage
        float speedSpawnChance = 0.10f; // 10% chance for speed (rarer)

        float randomValue = Random.Range(0f, 1f);
        if (randomValue < healthSpawnChance)
        {
            return healthPowerUpPrefab;
        }
        else if (randomValue < healthSpawnChance + damageSpawnChance)
        {
            return damagePowerUpPrefab;
        }
        else
        {
            return speedPowerUpPrefab;
        }
    }
}
   