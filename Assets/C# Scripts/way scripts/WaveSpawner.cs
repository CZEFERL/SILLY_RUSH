using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnpoint;

    public float timeBetweenWaves = 7f;
    private float countdown = 1.5f;
    private float addedTimeBetweenWaves = 0f;

    private int waveIndex = 0;

    void Update ()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves + addedTimeBetweenWaves;
            addedTimeBetweenWaves += 3f;
            return;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave ()
    {
        Wave wave = waves[waveIndex];

        for (int i = 0;  i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
    }

    void SpawnEnemy (GameObject enemy)
    {
        Instantiate(enemy, spawnpoint.position, spawnpoint.rotation);
        EnemiesAlive++;
    }
}