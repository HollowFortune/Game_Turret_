using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_HP : MonoBehaviour
{
    [SerializeField] private BoxCollider2D enemy_hitbox;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public EnemySpawner enemy_count_func;

    private void Start()
    {
        enemy_hitbox = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
       enemy_count_func = FindAnyObjectByType<EnemySpawner>();
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            Destroy(enemy);
            enemy_count_func.max_enemy_count--;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(enemy);
        }

    }
}
