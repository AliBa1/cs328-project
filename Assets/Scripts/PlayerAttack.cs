using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    public GameObject protagonist;
    public int attackDamage = 10;
    public Vector2 knockback = Vector2.zero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damagable damageable = collision.GetComponent<Damagable>();

        if (damageable != null)
        {
            Vector2 deliveredKnockback = transform.parent.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);

            bool gotHit = damageable.Hit(attackDamage, deliveredKnockback);

            if (gotHit)
            {
                if(collision.tag == "Boss")
                {
                    protagonist.GetComponent<Damagable>().Health -= 5;
                }
                Debug.Log(collision.name + " hit for " + attackDamage);
            }
        }
    }
}
