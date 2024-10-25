using System.Collections;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject healthPowerUpPrefab; // Reference to health power-up prefab
    [SerializeField] private GameObject damagePowerUpPrefab; // Reference to damage power-up prefab
    [SerializeField] private GameObject speedPowerUpPrefab; // Reference to speed power-up prefab

    [SerializeField] private float spawnInterval = 5f; // Time between spawns
    [SerializeField] private float spawnDistance = 5f; // Distance around the player to spawn power-ups

    private Transform playerTransform; // Reference to the player's transform

    private void Start()
    {
        // Find the player in the scene (ensure the player has the "Player" tag)
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnPowerUps());
    }

    private IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            // Randomly choose which power-up to spawn
            GameObject powerUpPrefab = ChooseRandomPowerUp();

            // Calculate a random spawn position around the player
            Vector2 spawnPosition = (Vector2)playerTransform.position + Random.insideUnitCircle * spawnDistance;

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
