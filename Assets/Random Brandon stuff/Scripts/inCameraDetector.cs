using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inCameraDetector : MonoBehaviour
{
    public Transform player;
    public Camera mainCamera;

    float xBuffer = 0.0f;
    float yBuffer = 0.1f;

    private void Update()
    {
        if (player != null && mainCamera != null)
        {
            Vector3 playerViewportPos = mainCamera.WorldToViewportPoint(player.position);

            bool isPlayerInXView = playerViewportPos.x >= -xBuffer && playerViewportPos.x <= 1 + xBuffer;

            bool isPlayerBelowYView = playerViewportPos.y >= -yBuffer;

            if (isPlayerInXView && isPlayerBelowYView)
            {
                //Debug.Log("Player is in the camera's view");
            }
            else
            {
                //Debug.Log("Player is not in the camera's view");
            }
        }
    }
}
