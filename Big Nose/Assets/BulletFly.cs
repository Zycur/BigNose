using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    Collider2D hitInfo;
    public int damage = 25;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.name == "Main Bird")
        {
            Health hp = (Health) hitInfo.gameObject.GetComponent(typeof(Health));
            hp.TakeDamage(damage);
        }
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }

}
