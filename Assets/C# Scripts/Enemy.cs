using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    void Start ()
    {
        target = Waypoints.points[0];
    }

    void Update ()
    {
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
        if (Vector3.Distance(transform.position, target.position) <= 0.02f)
        {
            transform.position = target.position;
            GetNextWaypoint();
            return;
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            WaveSpawner.EnemiesAlive--;
        }
        else
        {
            wavepointIndex++;
            target = Waypoints.points[wavepointIndex];
        }
    }
}
