using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectileScript : MonoBehaviour
{
    private Transform target;
    private float speed;
    private int damage;
    
    void Update()
    {
        Move();
    }

    public void SetTarget(Transform enemy, int damage, float speed)
    {
        target = enemy;
        this.damage = damage;
        this.speed = speed;
    }

    private void Move()
    {
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) < 0.1f)
            {
                target.GetComponent<Enemy>().TakeDamage(damage);
                Destroy(gameObject);
            }
            else
            {
                Vector2 dir = target.position - transform.position;
                transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);
            }
        }
        else
            Destroy(gameObject);
    }
}
