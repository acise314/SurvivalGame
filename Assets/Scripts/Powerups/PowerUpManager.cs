using System.Collections;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject healthPowerUpPrefab;
    public GameObject damagePowerUpPrefab;
    public Transform playerTransform;
    public float spawnDistance = 5f;
    public float spawnInterval = 10f; // Time between spawns

    private void Start()
    {
        StartCoroutine(SpawnPowerUps());
    }

    private IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            // Spawn health power-up
            if (Random.value <= 0.5f) // 50% chance
            {
                SpawnPowerUp(healthPowerUpPrefab);
            }
            // Spawn damage power-up
            if (Random.value <= 0.5f) // 50% chance
            {
                SpawnPowerUp(damagePowerUpPrefab);
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnPowerUp(GameObject powerUpPrefab)
    {
        Vector2 spawnPosition = (Vector2)playerTransform.position + Random.insideUnitCircle * spawnDistance;
        Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
    }
}
