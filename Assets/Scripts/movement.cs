using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    bool grounded;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("ground"))
        {
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("ground"))
        {
            grounded = false;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        moveSpeed = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = Vector2.left * moveSpeed;
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector2.right * moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.W) && grounded == true)
        {
            rb.velocity = Vector2.up * 10;
        }
    }
}
