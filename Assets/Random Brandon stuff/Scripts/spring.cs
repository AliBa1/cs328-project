using UnityEngine;

public class Spring : MonoBehaviour
{
    public float launchForce = 10f; // Adjust this value to control the launch force

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone");
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                Debug.Log("Player Rigidbody2D found");
                LaunchPlayer(playerRb);
            }
            else
            {
                Debug.LogError("Player Rigidbody2D not found!");
            }
        }
    }

    private void LaunchPlayer(Rigidbody2D playerRb)
    {
        // Apply an upward force to launch the player;
        playerRb.velocity = new Vector2(playerRb.velocity.x, launchForce);
        Debug.Log("Player launched!");
    }
}
