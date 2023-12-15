using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class swordScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int attackDamage = 10;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damagable damageable = collision.GetComponent<Damagable>();

        if (damageable != null)
        {
            collision.GetComponent<Damagable>().Health -= attackDamage;
            Debug.Log(collision.name + " hit for " + attackDamage + " damage");
        }
        Destroy(gameObject);
    }
}
