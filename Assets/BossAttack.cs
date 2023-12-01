using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossAttack : MonoBehaviour
{
    public GameObject bigBad;
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
                Debug.Log(collision.name + " hit for " + attackDamage);
                bigBad.GetComponent<Damagable>().Health += 10;
                if(bigBad.GetComponent<Damagable>().Health > 100)
                {
                    bigBad.GetComponent<Damagable>().Health = 100;
                }
            }
        }
    }
}
