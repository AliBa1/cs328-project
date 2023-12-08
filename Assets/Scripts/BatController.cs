// contine from: https://youtu.be/Kz7j-Gh1nZ0?si=Ul5e9QRy_jcZDi4F&t=2027
using System;
using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public float flightSpeed = 3f;
    public float waypointReachedDistance = 0.1f;
    public DetectionZone biteDetectionZone;
    public List<Transform> waypoints;

    Animator animator;
    Rigidbody2D rb;
    Damagable damagable;

    Transform nextWaypoint;
    int waypointNum = 0;

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
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        damagable = GetComponent<Damagable>();
    }

    private void Start() {
        nextWaypoint = waypoints[waypointNum];
    }

    // Update is called once per frame
    void Update()
    {
        HasTarget = biteDetectionZone.detectedColliders.Count > 0;
    }

    private void FixedUpdate() {
        if(damagable.IsAlive) {
            if (CanMove) {
                Flight();
            } else {
                rb.velocity = Vector3.zero;
            }
        } else {
            // if dead will fall
            rb.gravityScale = 2f;
        }
    }

    private void Flight() {
        // fly to waypoint
        Vector2 directionToWaypoint = (nextWaypoint.position - transform.position).normalized;

        // check if at waypoint
        float distance = Vector2.Distance(nextWaypoint.position, transform.position);

        rb.velocity = directionToWaypoint * flightSpeed;

        UpdateDirection();

        // check if need to change waypoint
        if (distance <= waypointReachedDistance) {
            // to next waypoint
            waypointNum++;

            if (waypointNum >= waypoints.Count) {
                waypointNum = 0;
            }

            nextWaypoint = waypoints[waypointNum];
        }
    }

    private void UpdateDirection() {
        Vector3 locScale = transform.localScale;
        if (transform.localScale.x > 0) {
            // facing right
            if(rb.velocity.x < 0) {
                // Flip
                transform.localScale = new Vector3(-1 * locScale.x, locScale.y, locScale.z);
            }
        } else {
            if (rb.velocity.x > 0) {
                transform.localScale = new Vector3(-1 * locScale.x, locScale.y, locScale.z);
            }
        }
    }
}
