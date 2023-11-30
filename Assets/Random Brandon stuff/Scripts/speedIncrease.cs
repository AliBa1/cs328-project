using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedIncrease : MonoBehaviour
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
        player.GetComponent<playerController>().walkSpeed = 7f;
        player.GetComponent<playerController>().runSpeed = 10f;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(15f);

        player.GetComponent<playerController>().walkSpeed = 5f;
        player.GetComponent<playerController>().runSpeed = 8f;

        Destroy(gameObject);
    }
}
