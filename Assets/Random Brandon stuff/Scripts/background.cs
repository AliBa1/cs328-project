using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    void Awake()
    {
        // Get the main camera
        Camera mainCamera = Camera.main;

        // Ensure the main camera exists
        if (mainCamera != null)
        {
            // Calculate camera aspect ratio
            float cameraAspect = mainCamera.aspect;

            // Calculate sprite size based on camera orthographic size and aspect ratio
            float cameraOrthographicSize = mainCamera.orthographicSize;
            float spriteWidth = 2 * cameraOrthographicSize * cameraAspect;

            // Set the size of the SpriteRenderer
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.size = new Vector2(spriteWidth, cameraOrthographicSize * 2f);
        }
        else
        {
            Debug.LogError("Main camera not found. Make sure you have a camera tagged as 'MainCamera'.");
        }
    }
}


