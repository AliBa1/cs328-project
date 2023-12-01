using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBoss : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public DetectionZone attackZone;

    public float walkSpeed;
    private float currentSpeed;
    private float coolDown;

    Rigidbody2D rigBod;

    private void Awake()
    {
        rigBod = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public bool _hasTarget = false;

    public bool hasTarget { get { return _hasTarget; } private set
        {
            _hasTarget = value;
            animator.SetBool(AnimationStrings.hasTarget, value);
        }
    }

    public bool _hasCrit = false;

    public bool hasCrit { get { return _hasCrit; } private set
        {
            _hasCrit = value;
            animator.SetBool(AnimationStrings.hasCrit, value);
        }
    }

    public bool canMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }

    void Update()
    {
        Vector3 scale = transform.localScale;

        if (player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x);
            if (!canMove || Mathf.Abs(player.transform.position.x - transform.position.x) < 1.5)
            {
                currentSpeed = 0;
            }else{
                currentSpeed = walkSpeed;
            }

            rigBod.velocity = new Vector2(currentSpeed * Vector2.right.x, rigBod.velocity.y);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * -1;
            if (!canMove || Mathf.Abs(player.transform.position.x - transform.position.x) < 1.5)
            {
                currentSpeed = 0;
            }else{
                currentSpeed = walkSpeed;
            }

            rigBod.velocity = new Vector2(currentSpeed * Vector2.left.x, rigBod.velocity.y);
        }

        transform.localScale = scale;
        animator.SetFloat("speed", Mathf.Abs(currentSpeed));

        int crit = Random.Range(1, 5);

        if(coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
        if((attackZone.detectedColliders.Count > 0) && (coolDown <= 0))
        {
            coolDown = 1f;
            hasTarget = true;
            if (crit == 4)
            {
                hasCrit = true;
            }
            else
            {
                hasCrit = false;
            }
        }
        else
        {
            hasTarget = false;
        }
    }

    public void OnHit(int damage, Vector2 knockback)
    {
        rigBod.velocity = new Vector2(knockback.x, rigBod.velocity.y + knockback.y);
    }
}
