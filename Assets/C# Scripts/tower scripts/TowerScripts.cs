using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerScripts : MonoBehaviour
{
    public bool isRotatable;
    public int money;

    public float splashRange = 0;
    public float projSpeed;
    public int damage;
    public float range;
    public float minRange = 0;
    public float CD;
    private float currentCD;
    
    private SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray = null;

    private int index = 2;
    public GameObject Projectile;
    private GameObject FunctionPanel;
    private GameObject shopPanel;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        PlayerStats.Money -= money;
    }

    private void Awake()
    {
        FunctionPanel = GameObject.Find("Canvas").transform.Find("FunctionPanel").gameObject;
        shopPanel = GameObject.Find("Canvas").transform.Find("Shop").gameObject;
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

            if (currDist < NearestEnemyDistance && currDist >= minRange && currDist <= range && !(TryGetComponent<MortarScript>(out MortarScript x) && enemy.TryGetComponent<PlaneChangeSprite>(out PlaneChangeSprite y)))
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

        if (isRotatable)
            Rotate(dir);

        if (TryGetComponent<MortarScript>(out MortarScript mortar))
            mortar.Rotate(enemy);

        GameObject proj = Instantiate(Projectile, transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));
        if (splashRange == 0)
            proj.GetComponent<TowerProjectileScript>().SetTarget(enemy, damage, projSpeed);
        else
            proj.GetComponent<SplashProjectileScript>().SetTarget(enemy, damage, projSpeed, splashRange);
    }

    void Rotate(Vector3 dir)
    {
        var x = SignedAngleToTarget(dir);
        switch (x)
        {
            case > 135:
                transform.eulerAngles = new Vector3(0, 0, -180);
                x -= 135;
                break;
            case > 45:
                transform.eulerAngles = new Vector3(0, 0, -90);
                x -= 45;
                break;
            case < -135:
                transform.eulerAngles = new Vector3(0, 0, 180);
                x += 225;
                break;
            case < -45:
                transform.eulerAngles = new Vector3(0, 0, 90);
                x += 135;
                break;
            default:
                transform.eulerAngles = new Vector3(0, 0, 0);
                break;
        }
        switch (x)
        {
            case < 11.25f:
                index = 5;
                break;
            case < 33.75f:
                index = 6;
                break;
            case < 56.25f:
                index = 7;
                break;
            case < 78.75f:
                index = 8;
                break;
            default:
                index = 9;
                break;
        }
        StartCoroutine(FireAnimation());
    }

    IEnumerator FireAnimation ()
    {
        spriteRenderer.sprite = spriteArray[index];
        index -= 5;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.sprite = spriteArray[index];
    }

    float SignedAngleToTarget(Vector3 dir)
    {
        float angle = Vector3.Angle(dir, new Vector3(1, 0, 0));
        float sign = Mathf.Sign(Vector3.Dot(new Vector3(0, 0, 1), Vector3.Cross(dir, new Vector3(1, 0, 0))));

        return angle * sign;
    }

    void OnMouseDown()
    {
        if (FunctionPanel.activeInHierarchy)
            return;

        if (shopPanel.activeInHierarchy)
            return;

        if (Time.timeScale == 0)
            return;

        FunctionPanel.SetActive(true);
        FunctionController.pole = gameObject;
    }
}
