using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float climbSpeed = 5f;
    private bool isOnLadder = false;

    void Update()
    {
        if (isOnLadder)
        {
            float verticalInput = Input.GetAxis("Vertical");
            Climb(verticalInput);
        }
    }

    void Climb(float verticalInput)
    {
        // Move the player up or down based on input
        transform.Translate(Vector3.up * verticalInput * climbSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isOnLadder = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isOnLadder = false;
        }
    }
}

