using System.Collections;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject powerUpPrefab; // A single prefab for all power-ups
    public Transform playerTransform; // Reference to the player's position

    private float spawnRadius = 5f;
    private float spawnInterval = 10f;

    void Start()
    {
        StartCoroutine(SpawnPowerUps());
    }

    private IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnPowerUp();
        }
    }

    private void SpawnPowerUp()
    {
        Vector2 spawnPosition = (Vector2)playerTransform.position + Random.insideUnitCircle * spawnRadius;
        GameObject newPowerUp = Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);

        // Randomly choose between Health or Damage power-up
        PowerUpEffect powerUpEffect;
        if (Random.Range(0, 2) == 0)
        {
            powerUpEffect = new HealthPowerUp(5); // Increase health by 5
            Debug.Log("Spawning Health PowerUp");
        }
        else
        {
            powerUpEffect = new DamagePowerUp(5f); // Increase damage by 5
            Debug.Log("Spawning Damage PowerUp");
        }

        // Initialize the spawned power-up with the selected effect
        newPowerUp.GetComponent<PowerUp>().Initialize(powerUpEffect);
    }
}
