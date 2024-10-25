using System.Collections;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject healthPowerUpPrefab; // Reference to health power-up prefab
    [SerializeField] private GameObject damagePowerUpPrefab; // Reference to damage power-up prefab
    [SerializeField] private GameObject speedPowerUpPrefab; // Reference to speed power-up prefab

    [SerializeField] private float spawnInterval = 5f; // Time between spawns
    [SerializeField] private float spawnAreaWidth = 10f; // Width of the spawn area
    [SerializeField] private float spawnAreaHeight = 10f; // Height of the spawn area

    private void Start()
    {
        StartCoroutine(SpawnPowerUps());
    }

    private IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            // Randomly choose which power-up to spawn
            GameObject powerUpPrefab = ChooseRandomPowerUp();

            // Calculate a random spawn position within the specified area
            Vector2 spawnPosition = new Vector2(
                Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2),
                Random.Range(-spawnAreaHeight / 2, spawnAreaHeight / 2)
            );

            // Instantiate the power-up prefab at the spawn position
            Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);

            // Wait for the specified interval before spawning the next power-up
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private GameObject ChooseRandomPowerUp()
    {
        int randomChoice = Random.Range(0, 3); // Randomly choose a number between 0 and 2

        switch (randomChoice)
        {
            case 0:
                return healthPowerUpPrefab; // Health power-up
            case 1:
                return damagePowerUpPrefab; // Damage power-up
            case 2:
                return speedPowerUpPrefab; // Speed power-up
            default:
                return healthPowerUpPrefab; // Default to health if something goes wrong
        }
    }
}
