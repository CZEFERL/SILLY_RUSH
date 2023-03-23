using UnityEngine;

[System.Serializable]
public class Wave
{
    public SubWave[] SubWaves;
    public float rate;

    public int EnemyCount()
    {
        int cnt = 0;
        for (var i = 0; i < SubWaves.Length; i++)
        {
            cnt += SubWaves[0].count;
        }
        return cnt;
    }
}

[System.Serializable]
public class SubWave
{
    public GameObject enemy;
    public int count;
    public float rate;
}
