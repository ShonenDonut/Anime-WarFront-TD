using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 8f;
    public int damage = 5;

    private Enemy target;

    public void SetTarget(Enemy newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        // enemy already died
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 targetPosition = target.transform.position;

        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        float distance = Vector2.Distance(transform.position, targetPosition);

        if (distance < 0.1f)
        {
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}