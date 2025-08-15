using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_basic_behavior : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 10f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player == null)
        {
            Debug.Log("Player not found!");
        }
    }
    private void Update()
    {
        if (player == null)
        {
            Debug.Log("Player not found!");
        }
        else
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
