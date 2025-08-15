using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy_basic;
    [SerializeField] private GameObject enemy_fast;
    [SerializeField] private GameObject enemy_inst;
    [SerializeField] private GameObject player;
    [SerializeField] private int spawn_chance;
    [SerializeField] private float spawn_buffer = 1.5f;
    [SerializeField] public int max_enemy_count = 0; //max amount of enemies allowed at a given time
    [SerializeField] public int round_enemy_count = 25; //the amount of enemies that will be spawned per round 
    [SerializeField] private int enemy_count = 0; //the amount of enemies that have been spawned in a round
    [SerializeField] private int min_spawn_distance = 8; //how far an enemy can begin to spawn from player
    [SerializeField] public int wave_counter = 1;
    [SerializeField] private bool isSpawning = false;
    //[SerializeField] private int max_spawn_distance = 30;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if(!isSpawning)
        StartCoroutine(Basic_Spawn());
        if(enemy_count >= round_enemy_count && !isSpawning)
        {
            NewRound();
        }
        
    }

    IEnumerator Basic_Spawn()
    {
        isSpawning = true;
        spawn_chance = Random.Range(0, 100);
        int spawn_pos_x = Random.Range(-10, 10);
        int spawn_pos_y = Random.Range(-10, 10);
        if (spawn_chance <= 35)
        {
            if (max_enemy_count <= 50 && enemy_count <= round_enemy_count)
            {
                Vector3 player_position = player.transform.position;
                if(spawn_pos_x < 0)
                {
                    spawn_pos_x = spawn_pos_x - min_spawn_distance;
                }
                else
                {
                   spawn_pos_x = spawn_pos_x + min_spawn_distance;    
                }
                if(spawn_pos_y < 0)
                {
                    spawn_pos_y = spawn_pos_y - min_spawn_distance;
                }
                else
                {
                    spawn_pos_y = spawn_pos_y + min_spawn_distance;
                }
                Vector3 enemy_spawn = new Vector3(spawn_pos_x, spawn_pos_y, 0);
                enemy_basic.transform.position = enemy_spawn;
                if (wave_counter > 2 && spawn_chance <= 10)
                {
                    enemy_fast.transform.position = enemy_spawn;
                    enemy_inst = Instantiate(enemy_fast, enemy_fast.transform.position, Quaternion.identity);
                }
                else
                {
                    enemy_basic.transform.position = enemy_spawn;
                    enemy_inst = Instantiate(enemy_basic, enemy_basic.transform.position, Quaternion.identity);
                }
                enemy_count++;
                max_enemy_count++;
                yield return new WaitForSeconds(spawn_buffer);
            }
        }
        isSpawning = false;
        yield return null;
    }

    private void NewRound()
    {
        wave_counter++;
        if (wave_counter % 2 == 0)
        {
            if(spawn_buffer > 0)
            spawn_buffer = spawn_buffer - 0.2f;
        }
        spawn_chance = spawn_chance + 5;
        round_enemy_count = round_enemy_count + 2 * wave_counter; //wave 2 will add 4 more enemies, wave 3 will add 6, wave 4 will add 8, etc.
        enemy_count = 0;
    }
}
