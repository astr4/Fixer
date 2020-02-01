using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveInput;
    private bool facingRight = true;
    public Transform groundCheck;
    private bool isGrounded;
    private Rigidbody2D rb;
    public float checkRadius;
    public float speed;
    public LayerMask whatIsGround;
    public Animator animator;
    private int extraJumps;
    public int extraJumpsValue;
    public float jumpForce;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis(("Horizontal"));
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == true && moveInput > 0)
            Flip();
        else if (facingRight == false && moveInput < 0)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(moveInput));
        if (isGrounded == true)
        {
            //animator.SetBool("isJumping", false);
            extraJumps = extraJumpsValue;
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            //animator.SetBool("isJumping", true);
            extraJumps--;
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
