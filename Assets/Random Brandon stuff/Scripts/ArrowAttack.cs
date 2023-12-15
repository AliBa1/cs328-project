using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class ArrowAttack : MonoBehaviour
{
    [SerializeField] private Transform ArrowPrefab;

    private bool canShoot = true;
    private float coolDown = 2f;
    private playerController controller;
    public Animator animator;

    private void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SpawnArrow();
        }
        controller = GetComponent<playerController>();
    }

    private void SpawnArrow()
    {
        if (canShoot)
        {
            // Instantiate the arrow at the player's position
            Transform arrowTransform = Instantiate(ArrowPrefab, transform.position, Quaternion.identity);

            // Access the Arrow script and set its direction based on the player's facing direction
            Arrow arrowScript = arrowTransform.GetComponent<Arrow>();

            if (arrowScript != null)
            {
                // Check if the player is facing right, and set the arrow direction accordingly
                if (GetComponent<playerController>().IsFacingRight)
                {
                    arrowScript.SetDirection(Vector3.right);
                }
                else
                {
                    arrowScript.SetDirection(Vector3.left);
                }
            }
            canShoot = false;
            StartCoroutine(CoolDown());
            StartCoroutine(LockMovement());
        }
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(coolDown);
        canShoot = true;
    }

    IEnumerator LockMovement()
    {
        if (controller != null)
        {
            animator.enabled = false;
            controller.walkSpeed = 0f;
            controller.runSpeed = 0f;
            controller.canJump = false;

            yield return new WaitForSeconds(.4f);

            controller.walkSpeed = 5f;
            controller.runSpeed = 8f;
            controller.canJump = true;
            animator.enabled = true;
        }
        else
        {
            Debug.LogError("Controller is null in LockMovement coroutine.");
        }
    }


}
