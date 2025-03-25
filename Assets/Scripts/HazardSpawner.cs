using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    public GameObject hazardPrefab;
    public float spawnRate = 1.5f;

    private float timer;

    // Adjust spawn position to stay within bounds
    [SerializeField] private float hazardMinX = -8.5f;
    [SerializeField] private float hazardMaxX = 8.5f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnHazard();
            timer = 0f;
        }
    }

    void SpawnHazard()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(hazardMinX, hazardMaxX), 10f, 0f);
                
        Instantiate(hazardPrefab, spawnPosition, Quaternion.identity);
    }
}
