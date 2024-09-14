using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyprefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 20;
    [SerializeField] private float enemiesPerSecond = 0.3f;


    private float timeSinceLastSpawn;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    private void Start()
    {
        isSpawning = true;
        enemiesLeftToSpawn = baseEnemies;
    }

    void Update()
    {
        if (GameManager.instance.gamePause) return;
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;

            timeSinceLastSpawn = 0f;
        }
    }

    private void SpawnEnemy()
    {
        int index = Random.Range(0, enemyprefabs.Length);
        GameObject prefabToSpawn = enemyprefabs[index];
        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }

}
