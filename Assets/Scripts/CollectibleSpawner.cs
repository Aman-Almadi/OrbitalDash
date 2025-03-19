using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public float spawnInterval = 2f;
    public float spawnRadius = 10f;

    private void Start()
    {
        InvokeRepeating("SpawnCollectible", 1f, spawnInterval);
    }

    void SpawnCollectible()
    {
        Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius;
        spawnPosition.y = 0.5f; // Keep collectibles on the ground
        Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);
    }
}
