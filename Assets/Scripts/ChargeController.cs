// To connect to player: https://youtu.be/ouzkNDIXg3I?si=-rZ4F0kD2_dKmO1q&t=237
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChargeController : MonoBehaviour
{
    public float speed;
    //public Vector2 moveSpeed = new Vector2(3f, 0);
    Rigidbody2D rb;
    // Start is called before the first frame update

    private void Awake() {
        //rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        //rb.velocity = new Vector2(moveSpeed.x * transform.localScale.x, moveSpeed.y);
    }

    // Update is called once per frame
    void Update()
    {
        //ERROR HERE
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            Destroy(gameObject);
        }
    }
}
