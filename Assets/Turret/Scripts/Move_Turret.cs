using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Turret : MonoBehaviour
{
    float rotation_speed = 150; //speed at which turret rotates
    public GameObject bullet;
    private GameObject bulletinst;

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //find x and y coord distance
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotation_speed * Time.deltaTime);
        if ((Input.GetMouseButtonDown(0)))
        {
            bulletinst = Instantiate(bullet, transform.position, rotation);
        }

    }
}
