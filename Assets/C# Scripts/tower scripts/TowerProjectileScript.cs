using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectileScript : MonoBehaviour
{
    Transform target;
    public float speed = 21;
    public int damage = 10;

    void Update()
    {
        Move();
    }

    public void SetTarget(Transform enemy)
    {
        target = enemy;
    }

    private void Move()
    {
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) < .1f)
            {
                target.GetComponent<Enemy>().TakeDamage(damage);
                Destroy(gameObject);
            }    
            else
            {
                Vector2 dir = target.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);
            }
        }
        else
            Destroy(gameObject);
    }

}
