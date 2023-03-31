using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public int health = 30;
    public int money = 40;

    private Transform target;
    private int wavepointIndex = 1;
    private Vector3 CorrVec;
    private Vector3 dir;
    private float angle;

    private bool xdir = Waypoints.XDirStart;
    private bool ydir = Waypoints.YDirStart;

    void Start ()
    {
        CorrVec = transform.position - Waypoints.points[0].position;
        target = Waypoints.points[wavepointIndex];

        if (Waypoints.points[1].position.x - Waypoints.points[0].position.x == 0)
            transform.position = new Vector3(transform.position.x, Waypoints.points[0].position.y);
        if (Waypoints.points[1].position.y - Waypoints.points[0].position.y == 0)
            transform.position = new Vector3(Waypoints.points[0].position.x, transform.position.y);
    }

    void Update ()
    {
        dir = target.position - transform.position + CorrVec;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.Translate(speed * Time.deltaTime * dir.normalized, Space.World);
        
        if (Vector3.Distance(transform.position, target.position + CorrVec) <= 0.01f)
        {
            transform.position = target.position + CorrVec;
            GetNextWaypoint();
            return;
        }

        CheckIsAlive();
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            endpath();
            WaveSpawner.EnemiesAlive--;
        }
        else
        {
            wavepointIndex++;

            target = Waypoints.points[wavepointIndex];

            if (wavepointIndex < Waypoints.points.Length - 2)
                GetNextCorVec();
        }
    }

    void GetNextCorVec()
    {
        if (Waypoints.points[wavepointIndex + 1].position.x - target.position.x != 0)
        {
            if (((Waypoints.points[wavepointIndex + 1].position.x > target.position.x)) != xdir)
            {
                xdir = !xdir;
                CorrVec.y = -CorrVec.y;
            }
        }
        else
        {
            if (((Waypoints.points[wavepointIndex + 1].position.y > target.position.y)) != ydir)
            {
                ydir = !ydir;
                CorrVec.x = -CorrVec.x;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void CheckIsAlive()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            WaveSpawner.EnemiesAlive--;
            PlayerStats.Money += money;
        }
    }

    void endpath()
    {
        System.Console.WriteLine(PlayerStats.Lives);
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

}
