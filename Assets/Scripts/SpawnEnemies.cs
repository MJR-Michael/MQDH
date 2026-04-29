using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [Header("Prefabs to spawn")]
    [SerializeField] private List<GameObject> spawnPrefabs = new List<GameObject>();

    [Header("Spawn Settings")]
    [SerializeField] private float spawnRadius = 20f;

    [SerializeField] private float minSpawnInterval = 5f;
    [SerializeField] private float maxSpawnInterval = 10f;

    private Coroutine spawnRoutine;

    private void Start()
    {
        spawnRoutine = StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        if (spawnPrefabs == null || spawnPrefabs.Count == 0)
        {
            Debug.LogWarning("No prefabs assigned to spawn.");
            return;
        }

        GameObject prefabToSpawn = spawnPrefabs[Random.Range(0, spawnPrefabs.Count)];

        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;

        Vector3 spawnPosition = new Vector3(
            transform.position.x + randomCircle.x,
            transform.position.y,
            transform.position.z + randomCircle.y
        );

        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}