using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float movespeed = 2f;

    private Rigidbody2D rb;
    private Transform checkpoint;
    private int index = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        checkpoint = EnemyManager.main.checkpoints[index];
    }

    void Update()
    {
        if (Vector2.Distance(checkpoint.position, transform.position) <= 0.1f)
        {
            index++;

            // Check if we've reached the end
            if (index >= EnemyManager.main.checkpoints.Length)
            {
                Debug.Log("End reached");
                rb.velocity = Vector2.zero;
                return;
            }

            // Move to next checkpoint
            checkpoint = EnemyManager.main.checkpoints[index];
        }
    }

    void FixedUpdate()
    {
        Vector2 direction = (checkpoint.position - transform.position).normalized;
        rb.velocity = direction * movespeed;
    }
}