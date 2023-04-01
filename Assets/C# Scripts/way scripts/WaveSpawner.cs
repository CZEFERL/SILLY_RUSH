using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform[] SpawnPoints;
    public static int SpawnsCount;

    public float timeBetweenWaves = 7f;
    private float countdown = 1.5f;
    private float addedTimeBetweenWaves = 0f;

    private int waveIndex = 0;

    public WinMenu WM;


    private void Start()
    {
        SpawnsCount = SpawnPoints.Length;
    }

    void Update ()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        //�������� ��� ����� ����
        if (waveIndex >= waves.Length)
        {
            WM.Win();
            enabled = false;
            return;
        }

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

        for (int i = 0;  i < wave.SubWaves.Length; i++)
        {
            EnemiesAlive = wave.EnemyCount();
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