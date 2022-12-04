using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectileScript : MonoBehaviour
{
    Transform target;
    float speed = 7;
    int damage = 10;

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
                Vector3 dir = target.position - transform.position;
                Quaternion lookRatation = Quaternion.LookRotation(dir);
                Vector3 rotation = lookRatation.eulerAngles;
                transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
                target.GetComponent<Enemy>().TakeDamage(damage);
                Destroy(gameObject);
            }    
            else
            {
                Vector2 dir = target.position - transform.position;

                transform.Translate(dir.normalized * Time.deltaTime * speed);
            }
        }
        else
            Destroy(gameObject);
    }

}
