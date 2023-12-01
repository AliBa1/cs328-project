using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackIncrease : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
        }
    }

    IEnumerator PickUp(Collider2D player)
    {
        player.GetComponent<Attack>().attackDamage = 50;

        GetComponent<SpriteRenderer>().enabled = false;
        // GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(15f);
        
        player.GetComponent<Attack>().attackDamage = 25;

        Destroy(gameObject);
    }
}
