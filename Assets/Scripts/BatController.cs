// contine from: https://youtu.be/Kz7j-Gh1nZ0?si=Oni1XSsDAjoG4TwJ&t=1721
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
        }
    }

    private void Flight() {
        // fly to waypoint
        Vector2 directionToWaypoint = (nextWaypoint.position - transform.position).normalized;

        // check if at waypoint
        float distance = Vector2.Distance(nextWaypoint.position, transform.position);

        rb.velocity = directionToWaypoint * flightSpeed;

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
}
