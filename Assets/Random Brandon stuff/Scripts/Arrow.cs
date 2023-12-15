using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Arrow : MonoBehaviour
{
    public float speed = 8f;
    private Vector3 moveDirection;
    private float lifetime = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 newPosition = transform.position + moveDirection * speed * Time.deltaTime;
        transform.position = newPosition;

        lifetime -= Time.deltaTime;

        if(lifetime < 0)
        {
            DestroyArrow();
        }
    }

    // Method to set the direction of the arrow
    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction.normalized;

        if(direction == Vector3.left)
        {
            FlipSprite();
        }
    }

    public void FlipSprite()
    {
        transform.localScale *= new Vector2(-1, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        }
        else
        {
            Damagable damagable = collision.GetComponent<Damagable>();

            if (damagable != null)
            {
                damagable.Hit(10, Vector2.zero);
            }

            DestroyArrow();
        }
    }

    private void DestroyArrow()
    {
        Destroy(gameObject);
    }
}
