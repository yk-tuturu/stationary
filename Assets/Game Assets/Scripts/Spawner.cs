using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyprefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 20;
    [SerializeField] private float enemiesPerSecond = 0.3f;

    [SerializeField] private Object[] spriteList;
    [SerializeField] private int maxIndex;


    private float timeSinceLastSpawn;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    private void Start()
    {
        isSpawning = true;
        enemiesLeftToSpawn = baseEnemies;

        spriteList = Resources.LoadAll("sprites", typeof(Sprite));
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
        int index = (int)Mathf.Round(Random.Range(0, maxIndex));
        GameObject prefabToSpawn = enemyprefabs[0];

        SpriteRenderer sprite = prefabToSpawn.GetComponent<SpriteRenderer>();
        sprite.sprite = Instantiate(spriteList[index]) as Sprite;

        Item item = prefabToSpawn.GetComponent<Item>();
        item.index = (int)Mathf.Floor(index/2);

        Instantiate(prefabToSpawn, transform.position,  Quaternion.Euler(0, 0, Random.Range(0, 360)));
    }
}
