using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Health_handler health;
    public float speed = 10.0f;
    public Transform groundCheck;
    public TrailRenderer tr;
    public LayerMask groundLayer;
    public Sprite dead;
    public bool isFacingRight = true;
    private bool isDashing;
    public float jumpingPower = 16f;
    private bool canDash = true;
    private bool canMove = true;
    private bool doubleJump;
    public float dashingPower = 24f;
    public bool isDarkness = true;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    private float horizontal;
    public Animator animator;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");  

        if (IsGrounded() && !Input.GetButton("Jump"))
        {
              doubleJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                 rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                 doubleJump = false;
            }
             else
            {
                if (!doubleJump)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                        doubleJump = true;
                    }
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
              rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); 
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
              StartCoroutine(Dash());
        }

        Flip();

        if (health.currentHealth <= 0)
        {
            Die();
        }

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        animator.SetBool("isDarkness", isDarkness);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Die()
    {
        canMove = false;
        animator.SetBool("Dead", true);
        GameOverManager.instance.OnPlayerDeath();
    }

    private void FixedUpdate()
    {
        if (isDashing || canMove == false)
        {
            return;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private void Flip()
    {
       if ((horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight) && canMove)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
            isFacingRight = !isFacingRight;
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        float dashDirection = isFacingRight ? 1f : -1f;
        rb.velocity = new Vector2(dashDirection * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

}
