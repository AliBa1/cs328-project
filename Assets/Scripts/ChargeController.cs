using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChargeController : MonoBehaviour
{
    
    public int damage = 15;
    public Vector2 speed = new Vector2(4f, 0);
    public Vector2 knockback = new Vector2(5, 2);
    Rigidbody2D rb;
    // WitchController witch;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(speed.x * transform.localScale.x, speed.y);
    }

    // Update is called once per frame
    void Update()
    {
        //ERROR HERE
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        
        // witchController = witch.GetComponent<WitchController>();
        // transform.Translate(witchController.WalkDirection * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damagable damageable = collision.GetComponent<Damagable>();

        if (damageable != null) {
            Vector2 deliveredKnockback = transform.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);

            bool gotHit = damageable.Hit(damage, deliveredKnockback);

            if (gotHit) {
                Debug.Log(collision.name + " hit for " + damage);
                Destroy(gameObject);
            }
        }
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     if (other.gameObject.tag == "Player") {
    //         Destroy(gameObject);
    //     }
    // }
}
