using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 10.0f;
    public Transform groundCheck;
    public TrailRenderer tr;
    public LayerMask groundLayer;
    private bool isFacingRight = true;
    private bool isDashing;
    public float jumpingPower = 16f;
    private bool canDash = true;
    private bool doubleJump;
    public float dashingPower = 24f;
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
            if (IsGrounded() || doubleJump)
            {
                 rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                 doubleJump = !doubleJump;
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

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private void Flip()
    {
       if (horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
            isFacingRight = !isFacingRight;
            /*Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;*/
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
