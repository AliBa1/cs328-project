using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBoss : MonoBehaviour
{
    public GameObject player;
    public Animator animator;

    public float walkSpeed;
    private float currentSpeed;

    Rigidbody2D rigBod;

    private void Awake()
    {
        rigBod = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;

        if(player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x);
            if (Mathf.Abs(player.transform.position.x - transform.position.x) < 2)
            {
                currentSpeed = 0;
            }
            else
            {
                currentSpeed = walkSpeed;
            }
            rigBod.velocity = new Vector2(currentSpeed * Vector2.right.x, rigBod.velocity.y);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * -1;
            if (Mathf.Abs(player.transform.position.x - transform.position.x) < 2)
            {
                currentSpeed = 0;
            }
            else
            {
                currentSpeed = walkSpeed;
            }
            rigBod.velocity = new Vector2(currentSpeed * Vector2.left.x, rigBod.velocity.y);
        }

        transform.localScale = scale;
        animator.SetFloat("speed", Mathf.Abs(currentSpeed));
    }
}
