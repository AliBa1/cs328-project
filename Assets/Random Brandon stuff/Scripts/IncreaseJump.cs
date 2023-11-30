using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private void Start()
    {

    }
    //public GameObject pickupEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
        }
    }

    IEnumerator PickUp(Collider2D player)
    {
        player.GetComponent<playerController>().jumpForce = 12f;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(15f);

        player.GetComponent<playerController>().jumpForce = 10;

        Destroy(gameObject);
    }
}