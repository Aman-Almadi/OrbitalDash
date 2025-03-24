using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    public GameObject hazardPrefab;
    public float spawnRate = 1f;
    public float spawnXRange = 5f;
    private float timer;

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
        float randomX = Random.Range(-spawnXRange, spawnXRange);
        Vector3 spawnPos = new Vector3(randomX, 10f, 0f);
        Instantiate(hazardPrefab, spawnPos, Quaternion.identity);
    }
}
