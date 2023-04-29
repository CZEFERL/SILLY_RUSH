using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashProjectileScript : MonoBehaviour
{
    private Vector3 targetpos;
    private float splashRange;
    private float speed;
    private int damage;

    void Update()
    {
        Move();
    }

    public void SetTarget(Vector3 enemypos, int damage, float speed, float splashRange)
    {
        targetpos = enemypos;
        this.damage = damage;
        this.speed = speed;
        this.splashRange = splashRange;
    }

    private void Move()
    {
        if (Vector2.Distance(transform.position, targetpos) < .1f)
        {
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                float currDist = Vector2.Distance(transform.position, enemy.transform.position);

                if (currDist <= splashRange)
                {
                    enemy.GetComponent<Enemy>().TakeDamage(CalculateSplashDamage(currDist));
                }
            }
            Destroy(gameObject);
        }
        else
        {
            Vector2 dir = targetpos - transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);
        }
    }

    private int CalculateSplashDamage(float dist)
    {
        return Mathf.RoundToInt(-damage * (dist * dist) / (splashRange * splashRange) + damage);
    }
}
