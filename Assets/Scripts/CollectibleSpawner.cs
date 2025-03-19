using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject[] collectiblePrefabs;
    public float spawnInterval = 2f;
    public float spawnRadius = 10f;
    public GameObject[] powerUpPrefabs;

    private void Start()
    {
        InvokeRepeating("SpawnCollectible", 1f, spawnInterval);
    }

    void SpawnCollectible()
    {
        GameObject prefabToSpawn;
        float randomValue = Random.value;

        if (randomValue < 0.8f)
        {
            prefabToSpawn = collectiblePrefabs[Random.Range(0, collectiblePrefabs.Length)];
        }
        else
        {
            prefabToSpawn = powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)];
        }

        Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius;
        spawnPosition.y = 0.5f; // Keep collectibles on the ground
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}
