using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HealthBarBehavior HealthBar;
    public float speed = 10f;
    public int maxHealth = 30;
    public WayPoints wayPoints { get; set; }
    private int health;
    
    public int money = 40;

    private Transform target;
    private int wavepointIndex = 1;

    private bool xdir;
    private bool ydir;
    private Vector3 CorrVec;

    public int Health
    {
        get {
            return health;
        }
    }

    void Start()
    {
        xdir = wayPoints.XDirStart;
        ydir = wayPoints.YDirStart;
        CorrVec = transform.position - wayPoints.points[0].position;
        target = wayPoints.points[wavepointIndex];

        if (wayPoints.points[1].position.x - wayPoints.points[0].position.x == 0)
            transform.position = new Vector3(transform.position.x, wayPoints.points[0].position.y);
        if (wayPoints.points[1].position.y - wayPoints.points[0].position.y == 0)
            transform.position = new Vector3(wayPoints.points[0].position.x, transform.position.y);

        health = maxHealth;
        HealthBar.SetHealth(health, maxHealth);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position + CorrVec;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.Translate(speed * Time.deltaTime * dir.normalized, Space.World);
        
        if (Vector3.Distance(transform.position, target.position + CorrVec) <= 0.03f)
        {
            transform.position = target.position + CorrVec;
            GetNextWaypoint();
            return;
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= wayPoints.points.Length - 1)
        {
            endpath();
        }
        else
        {
            wavepointIndex++;

            target = wayPoints.points[wavepointIndex];

            if (wavepointIndex < wayPoints.points.Length - 2)
                GetNextCorVec();
        }
    }

    void GetNextCorVec()
    {
        if (wayPoints.points[wavepointIndex + 1].position.x - target.position.x != 0)
        {
            if (((wayPoints.points[wavepointIndex + 1].position.x > target.position.x)) != xdir)
            {
                xdir = !xdir;
                CorrVec.y = -CorrVec.y;
            }
        }
        else
        {
            if (((wayPoints.points[wavepointIndex + 1].position.y > target.position.y)) != ydir)
            {
                ydir = !ydir;
                CorrVec.x = -CorrVec.x;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        HealthBar.SetHealth(health, maxHealth);
        CheckIsAlive();
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
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

}
