using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HP_Turret : MonoBehaviour
{
    [SerializeField] public int Player_HP = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("enemy"))
        {
            Player_HP--;
        }
    }

    private void Update()
    {
        if (Player_HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
