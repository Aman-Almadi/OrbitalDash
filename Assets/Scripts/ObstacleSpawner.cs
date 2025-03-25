using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public int obstacleCount = 10;

    [SerializeField] private Transform player;
    [SerializeField] private float minSpawnDistanceFromPlayer = 2f;

    // Define play area bounds
    [SerializeField] private float minX = -9f;
    [SerializeField] private float maxX = 9f;
    [SerializeField] private float minY = -9f;
    [SerializeField] private float maxY = 9f;

    private void Start()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        Vector3 spawnPosition;
        do
        {
            spawnPosition = new Vector3(Random.Range(minX, maxX), 0.5f, Random.Range(minY, maxY));
        }
        while (Vector3.Distance(spawnPosition, player.position) < minSpawnDistanceFromPlayer);

        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
