using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerScripts : MonoBehaviour
{
    private float range = 2;
    public float currentCD, CD;

    public GameObject Projectile;

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

        GameObject proj = Instantiate(Projectile);
        proj.transform.position = transform.position;
        proj.GetComponent<TowerProjectileScript>().SetTarget(enemy);
    }


}
