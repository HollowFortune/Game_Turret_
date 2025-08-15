using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic_Manager : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject hp_obj;
    [SerializeField] private GameObject wave_obj;
    [SerializeField] private GameObject enemy_manager;
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private TextMesh hp;
    [SerializeField] private TextMesh round;
    [SerializeField] private HP_Turret HP_Turret;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        HP_Turret = Player.GetComponent<HP_Turret>();
        hp_obj = GameObject.FindWithTag("HP");        
        hp = hp_obj.GetComponent<TextMesh>();


        enemy_manager = GameObject.FindWithTag("enemy_manager");
        spawner = enemy_manager.GetComponent<EnemySpawner>();
        wave_obj = GameObject.FindWithTag("round");
        round = wave_obj.GetComponent<TextMesh>();
        
    }

    // Update is called once per frame
    void Update()
    {
        hp.text = HP_Turret.Player_HP.ToString();

        round.text = spawner.wave_counter.ToString();
    }
}
