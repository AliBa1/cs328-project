
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    // Flag to track if the player has the key
    private bool hasKey = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hasKey = true;

            Destroy(gameObject);
        }
    }

    // You can provide a public method to check if the player has the key
    public bool HasKey()
    {
        return hasKey;
    }
}
