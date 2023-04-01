using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerScripts : MonoBehaviour
{
    public int money;
    private float range = 2;
    public float CD;
    private float currentCD;

    public GameObject Projectile;

    private void Start()
    {
        PlayerStats.Money -= money;
    }

    private void Update()
    {
        if (CanShoot())
            SearchTarget();
        if (currentCD > 0)
            currentCD -= Time.deltaTime;
    }

    bool CanShoot()
    {
        if (currentCD <= 0)
            return true;
        return false;
    }

    void SearchTarget()
    {
        Transform NearestEnemy = null;
        double NearestEnemyDistance = Mathf.Infinity;

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float currDist = Vector2.Distance(transform.position, enemy.transform.position);

            if (currDist < NearestEnemyDistance && currDist <= range)
            {
                NearestEnemy = enemy.transform;
                NearestEnemyDistance = currDist;
            }
        }

        if (NearestEnemy != null)
            Shoot(NearestEnemy);
    }

    void Shoot(Transform enemy)
    {
        currentCD = CD;
        
        Vector3 dir = enemy.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        GameObject proj = Instantiate(Projectile, transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));
        proj.GetComponent<TowerProjectileScript>().SetTarget(enemy);
    }


}
