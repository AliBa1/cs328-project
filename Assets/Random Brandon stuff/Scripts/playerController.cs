using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof (Damagable))]
public class playerController : MonoBehaviour
{
    public float walkSpeed;
    public float runSpeed;
    public float jumpForce;
    public float fallMulti;
    public float climbSpeed;
    public float jumpGracePeriod;
    private bool isOnLadder = false;
    public bool canJump;
    private bool grounded;
    Vector2 moveInput;
    public HealthBarController healthBar;
    Damagable damagable;
    [SerializeField]
    private float delayBeforeLoading = 3f;

    private float timeElapsed;

    public AudioSource swing;

    public float currentMoveSpeed {  get
        {
            if (CanMove) {
                if (IsMoving)
                {
                    if (IsRunning)
                    {
                        return runSpeed;
                    }
                    else
                    {
                        return walkSpeed;
                    }
                }
                else
                {
                    return 0;
                }
            } else {
                return 0;
            }
                
        }
    }

    private bool _isMoving = false;

    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            animator.SetBool("IsMoving", value);
        }

    }

    private bool _isRunning = false;

    public bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        set
        { 
            _isRunning = value;
            animator.SetBool("IsRunning", value );
        }
    }

    public bool _IsFacingRight = true;
    public bool IsFacingRight {
        get
        {
            return _IsFacingRight;
        }
        set
        {
            if (_IsFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }

            _IsFacingRight = value;
        }

    }

    public bool IsAlive {
        get {
            return animator.GetBool(AnimationStrings.isAlive);
        }
    }

    public bool CanMove {
        get {
            return animator.GetBool(AnimationStrings.canMove);
        }

        private set {

        }
    }

    

    Rigidbody2D rb;
    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        damagable = GetComponent<Damagable>();

        walkSpeed = 5f;
        runSpeed = 8f;
        jumpForce = 10f;
        fallMulti = 2.5f;
        climbSpeed = 5f;
        jumpGracePeriod = 0.1f;

        Cursor.visible = false;

}

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        // if (!damagable.LockVelocity) {
        //     rb.velocity = new Vector2(moveInput.x * currentMoveSpeed, rb.velocity.y);
        // }
        
        if (!damagable.IsHit) {
            rb.velocity = new Vector2(moveInput.x * currentMoveSpeed, rb.velocity.y);
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMulti - 1) * Time.fixedDeltaTime;
        }

        if  (!IsAlive) {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > delayBeforeLoading) {
                SceneManager.LoadScene("MainMenu");
                Cursor.visible = true;
            }
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if  (IsAlive) {
            IsMoving = moveInput != Vector2.zero;

            SetFacingDirection(moveInput);
        } else {
            IsMoving = false;
        }
        
    }

    private void SetFacingDirection(object moveSpeed)
    {
        if(moveInput.x > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        else if(moveInput.x < 0 && IsFacingRight)
        {
            IsFacingRight= false;
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsRunning = true;
        }
        else if (context.canceled)
        {
            IsRunning = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started && grounded && canJump && CanMove)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            canJump = false;
        }
    }

    public void onClimb(InputAction.CallbackContext context)
    {
        if(context.started && isOnLadder)
        {
            rb.velocity = new Vector2(rb.velocity.x, climbSpeed);
        }
        else if (context.canceled)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            grounded = true;
            canJump = true;
            //Debug.Log("Grounded");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player is not in the process of jumping
        if (!IsJumping() && collision.gameObject.tag == "Platform")
        {
            // Delay setting grounded to false to allow for a grace period
            StartCoroutine(DisableGrounded());
        }
    }

    bool IsJumping()
    {
        // Check if the player is moving upwards (jumping)
        return rb.velocity.y > 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered trigger zone");
        if (other.CompareTag("Ladder"))
        {
            isOnLadder = true;
            Debug.Log("on ladder");

            // Use GetComponent<Rigidbody2D>() instead of GetComponent<Rigidbody>()
            rb.gravityScale = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isOnLadder = false;
            rb.gravityScale = 1f;
        }
    }

    IEnumerator DisableGrounded()
    {
        yield return new WaitForSeconds(jumpGracePeriod);
        grounded = false;
        // Debug.Log("UnGrounded");
    }

    IEnumerator DisableJumpForGracePeriod()
    {
        yield return new WaitForSeconds(jumpGracePeriod);
        canJump = false;
    }

    public void OnAttack(InputAction.CallbackContext context) {
        if (context.started) {
            animator.SetTrigger(AnimationStrings.attackTrigger);
            swing.Play();
        }
    }

    public void OnHit(int damage, Vector2 knockback) {
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }
}
