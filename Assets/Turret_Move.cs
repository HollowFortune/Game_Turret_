using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       float rotation_speed = 60;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform, rotation, rotation, rotation_speed * Time.deltaTime);
        //vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }
}
