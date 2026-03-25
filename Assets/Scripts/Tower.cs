using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Tower Stats")]
    public float range = 3f;
    public float fireRate = 1f;
    public int damage = 5;
    public GameObject projectilePrefab;

    private float fireCountdown = 0f;
    private Enemy target;

    void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        float distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance > range)
        {
            target = null;
            return;
        }

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void FindTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        float shortestDistance = Mathf.Infinity;
        Enemy nearestEnemy = null;

        foreach (Enemy enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            if (distance < shortestDistance && distance <= range)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        target = nearestEnemy;
    }

    void Shoot()
    {
        if (projectilePrefab == null || target == null) return;

        GameObject projectileObj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Projectile projectile = projectileObj.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.damage = damage;
            projectile.SetTarget(target);
        }
    }
}