using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    public GameObject waterPrefab;
    public float spawnRate = 0.1f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnWater), 0f, spawnRate);
    }

    void SpawnWater()
    {
        Instantiate(waterPrefab, transform.position, Quaternion.identity);
    }
}
