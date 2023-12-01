using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    // Assuming you have a reference to the Player GameObject
    public GameObject player;

    void Start()
    {
        // If player is not assigned, try to find it in the scene
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Damagable damagable = player.GetComponent<Damagable>();

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
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
