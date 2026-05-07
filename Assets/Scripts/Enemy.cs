using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    public Transform[] waypoints;
    public float speed = 2f;

    [Header("Stats")]
    public int health = 20;
    public int reward = 10;
    public int baseDamage = 1;

    private int waypointIndex = 0;

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0)
            return;

        if (waypointIndex >= waypoints.Length)
        {
            ReachBase();
            return;
        }

        Transform target = waypoints[waypointIndex];

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target.position) < 0.05f)
        {
            waypointIndex++;
        }
    }

    public void InitializeEnemy(int waveNumber)
    {
        health += waveNumber * 5;
        speed += waveNumber * 0.1f;
        reward += waveNumber * 2;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddCurrency(reward);
            }

            Destroy(gameObject);
            return;
        }
    }

    private void ReachBase()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.TakeBaseDamage(baseDamage);
        }

        Destroy(gameObject);
    }
}