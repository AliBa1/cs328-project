// Layers needed
//Continue from here to connect with world: https://youtu.be/I6WSqFDLHiQ?si=KpO1Ypn2RCyLZwv-&t=1072
//Layers for detection zone https://youtu.be/hl9q6IWiVqA?si=knTtfX9Oc3a1zjr5&t=619
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class WitchController : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float walkStopRate = 0.6f;
    public DetectionZone attackZone;
    public GameObject charge;
    private float shotCooldown;
    public float startShotCooldown;

    Rigidbody2D rb;
    TouchingDirections touchingDirections;
    Animator animator;

    public enum WalkableDirection { Right, Left };

    private WalkableDirection _walkDirection;
    private Vector2 walkDirectionVector = Vector2.right;

    public WalkableDirection WalkDirection {
        get {
            return _walkDirection; 
        }
        set {
            if (_walkDirection != value){
                //Flip
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                if (value == WalkableDirection.Right) {
                    walkDirectionVector = Vector2.right;
                } else if (value == WalkableDirection.Left) {
                    walkDirectionVector = Vector2.left;
                }
            }
            _walkDirection = value;
        }
    }

    public bool _hasTarget = false;

    public bool HasTarget { get{ return _hasTarget; } private set
    {
        _hasTarget = value;
        animator.SetBool(AnimationStrings.hasTarget, value);
    } 
    }

    public bool CanMove {
        get {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        animator = GetComponent<Animator>();
        shotCooldown = startShotCooldown;
    }



    // Update is called once per frame
    void Update()
    {
        HasTarget = attackZone.detectedColliders.Count > 0;
    }

    private void FixedUpdate() {
        if (touchingDirections.IsGrounded && touchingDirections.IsOnWall) {
            FlipDirection();
        }
        
        if(CanMove) {
            //rb.velocity = new Vector2(walkSpeed * walkDirectionVector.x, rb.velocity.y);
        } else {
            //rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, walkStopRate), rb.velocity.y);
        }

        if(shotCooldown<=0 && _hasTarget) {
            Instantiate(charge, transform.position, charge.transform.rotation);
            // GameObject projectile = Instantiate(charge, transform.position, charge.transform.rotation);
            // Vector3 origScale = projectile.transform.localScale;
            // projectile.transform.localScale = new Vector3(
            //     origScale.x * transform.localScale.x > 0 ? 1 : -1,
            //     origScale.y,
            //     origScale.z
            // );
            shotCooldown = startShotCooldown;
        } else {
            shotCooldown -= Time.deltaTime;
        }
    
    }

    private void FlipDirection() {
        if (WalkDirection == WalkableDirection.Right) {
            WalkDirection = WalkableDirection.Left;
        } else if (WalkDirection == WalkableDirection.Left) {
            WalkDirection = WalkableDirection.Right;
        } else {
            Debug.LogError("Current walkable direction not set to right or left");
        }
    }
}