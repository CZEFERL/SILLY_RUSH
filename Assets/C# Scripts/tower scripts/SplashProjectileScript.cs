using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashProjectileScript : MonoBehaviour
{
    private Vector3 targetpos;
    private float splashRange;
    private float speed;
    private int damage;
    public AnimationCurve curve;
    public AnimationCurve speedCurve;
    private float xStart;

    void Update()
    {
        Move();
    }

    public void SetTarget(Transform enemy, int damage, float speed, float splashRange)
    {
        targetpos = enemy.position;
        this.damage = damage;
        this.speed = speed;
        this.splashRange = splashRange;
        xStart = transform.position.x;
        this.speed = Mathf.Max(speed * Vector3.Distance(transform.position, targetpos) / 10, 7);
    }

    private void Move()
    {

        if (Vector2.Distance(transform.position, targetpos) < 0.2f)
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
            float dist = Mathf.Abs(targetpos.x - xStart);
            var x = Mathf.Abs(transform.position.x - xStart) / dist;
            dir.y += curve.Evaluate(x);
            transform.Translate(dir.normalized * Time.deltaTime * speed * speedCurve.Evaluate(x), Space.World);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 45));
        }
    }

    private int CalculateSplashDamage(float dist)
    {
        return Mathf.RoundToInt(-damage / 2 * (dist * dist) / (splashRange * splashRange) + damage);
    }
}
