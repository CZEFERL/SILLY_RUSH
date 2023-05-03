using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive;

    public Wave[] waves;

    public Transform[] SpawnPoints;
    public static int SpawnsCount;

    public float timeBetweenWaves = 7f;
    public float timeIncrease;
    private float countdown;
    private float addedTimeBetweenWaves;
    

    private static int StartIndex = 0;
    private int waveIndex;

    public WinMenu WM;
    public LoseMenu LM;


    private void Start()
    {
        EnemiesAlive = 0;
        SpawnsCount = SpawnPoints.Length;
        waveIndex = StartIndex;
        addedTimeBetweenWaves = 0f;
        countdown = 1.5f;
    }

    void Update ()
    {
        if (PlayerStats.Lives <= 0)
        {
            LM.Lose();
            return;
        }

        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex >= waves.Length)
        {
            WM.Win();
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves + addedTimeBetweenWaves;
            addedTimeBetweenWaves += timeIncrease;
            return;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave ()
    {
        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.EnemyCount();
        for (int i = 0;  i < wave.SubWaves.Length; i++)
        {
            for (int j = 1; j < wave.SubWaves[i].count; j++)
            {
                SpawnEnemy(wave.SubWaves[i].enemy, wave.SubWaves[i].SpawnInd);
                yield return new WaitForSeconds(wave.SubWaves[i].time);
            }
            SpawnEnemy(wave.SubWaves[i].enemy, wave.SubWaves[i].SpawnInd);
            if (i != wave.SubWaves.Length - 1)
                yield return new WaitForSeconds(wave.time);
        }
        waveIndex++;
    }

    void SpawnEnemy (GameObject enemy, int SpawnNum)
    {
        if (SpawnNum == SpawnsCount)
        {
            //Spawns enemies on both side lines
            Instantiate(enemy, SpawnPoints[1].position, SpawnPoints[1].rotation);
            Instantiate(enemy, SpawnPoints[^1].position, SpawnPoints[^1].rotation);
        }
        else
            Instantiate(enemy, SpawnPoints[SpawnNum].position, SpawnPoints[SpawnNum].rotation);
    }
}