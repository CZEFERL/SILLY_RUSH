using UnityEngine;

[System.Serializable]
public class Wave
{
    public SubWave[] SubWaves;
    public float time;

    public int EnemyCount()
    {
        int cnt = 0;
        for (var i = 0; i < SubWaves.Length; i++)
        {
            cnt += (SubWaves[i].SpawnInd == WaveSpawner.SpawnsCount) ? SubWaves[i].count * 2 : SubWaves[i].count;
        }
        return cnt;
    }
}

[System.Serializable]
public class SubWave
{
    public GameObject enemy;
    public int LineInd;
    public int SpawnInd;
    public int count;
    public float time;
}
