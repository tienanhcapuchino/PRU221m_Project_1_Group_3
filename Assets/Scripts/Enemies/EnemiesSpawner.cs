using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public GameObject[] wave1;
    [SerializeField] public GameObject[] wave2;
    [SerializeField] public GameObject[] wave3;
    [SerializeField] public GameObject[] wave4;

    [Header("Attributes")]
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyScallingFactor = 0.75f;

    [Header("Event")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isPawning = false;
    private int count = 0;
    private int wave = 1;

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }
    private void Start()
    {
        enemyPrefab = wave1;
        StartCoroutine(StartWave());
    }
    private void Update()
    {
        if (!isPawning) return;
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemies(enemyPrefab[count]);
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
            count++;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }
    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }
    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isPawning = true;
        //enemiesLeftToSpawn = EnemiesPerWave();
        enemiesLeftToSpawn = enemyPrefab.Length;
    }
    private void EndWave()
    {
        //Array.Clear(enemyPrefab, 0, enemyPrefab.Length);
        wave++;
        if (wave == 2) enemyPrefab = wave2;
        if (wave == 3) enemyPrefab = wave3;
        if (wave == 4) enemyPrefab = wave4;
        count = 0;
        isPawning = false;
        timeSinceLastSpawn= 0f;
        currentWave++;
        StartCoroutine(StartWave());
    }
    private void SpawnEnemies(GameObject enemy)
    {
        Instantiate(enemy, LevelManager.main.Startpoint.position, Quaternion.identity);
        //int randomIndex = Random.Range(0, enemyPrefab.Length);
        //GameObject prefabToSpawn = enemyPrefab[randomIndex];
        //Instantiate(prefabToSpawn, LevelManager.main.Startpoint.position, Quaternion.identity);
    }
}
