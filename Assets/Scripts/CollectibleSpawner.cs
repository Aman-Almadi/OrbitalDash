using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject[] collectiblePrefabs;
    public float spawnInterval = 2f;
    public float spawnRadius = 10f;

    private void Start()
    {
        InvokeRepeating("SpawnCollectible", 1f, spawnInterval);
    }

    void SpawnCollectible()
    {
        GameObject prefabToSpawn = collectiblePrefabs[Random.Range(0, collectiblePrefabs.Length)];
        Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius;
        spawnPosition.y = 0.5f; // Keep collectibles on the ground
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}
