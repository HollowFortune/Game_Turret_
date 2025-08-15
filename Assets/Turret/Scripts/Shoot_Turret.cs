using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Turret : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rigidbody2;
    public GameObject bullet;
    [SerializeField] private float bullet_speed = 10f;
    [SerializeField] private float despawn_time = 4f;

    // Start is called before the first frame update

    public enum BulletType
    {
     normal,
     other
    }
    public BulletType bulletType;
    void Start()
    {
       rigidbody2 = GetComponent<Rigidbody2D>();
       setVelocity();
       StartCoroutine(BulletDespawn(despawn_time));
    }
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if(other.CompareTag("bullet_despawn"))
    //    {
    //        Debug.Log("working");
    //        Destroy(bullet);
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("enemy"))
        {
            Destroy(bullet);

        }
    }
    private void setVelocity()
    {
        rigidbody2.velocity = transform.right * bullet_speed;
    }

    private IEnumerator BulletDespawn(float despawn)
    {
        yield return new WaitForSeconds(despawn);
        Destroy(bullet);
    }
}
