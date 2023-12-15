using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Damagable damagable = other.GetComponent<Damagable>();

            // Check if the Damagable component is found
            if (damagable != null)
            {
                // Add 50 to the player's health
                damagable.Health += 50;
            }
            if (damagable.Health > 100)
            {
                damagable.Health = 100;
            }
            StartCoroutine(PickUp(other));
        }
    }

    IEnumerator PickUp(Collider2D player)
    {
        player.GetComponent<playerController>().walkSpeed = 7f;
        player.GetComponent<playerController>().runSpeed = 10f;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(10f);

        player.GetComponent<playerController>().walkSpeed = 5f;
        player.GetComponent<playerController>().runSpeed = 8f;

        Destroy(gameObject);
    }
}
