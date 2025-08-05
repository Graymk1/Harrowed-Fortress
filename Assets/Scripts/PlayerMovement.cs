using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Setting")]
    public float walkSpeed = 5f;
    public Rigidbody2D rb;
    public GameObject swordRotator;

    public static PlayerMovement instance;
    public Transform groundCheckPoint;
    public LayerMask groundLayer;

    private float groundCheckRadius = 0.2f;

    [Header("Jump Setting")]
    public float jumpHeight = 16f;
    public int maxJumps = 1;
    private int numJumps;

    [Header("Dash Setting")]
    public int maxDashes = 1;
    private int numDashes;
    public float dashStrength = 10f;
    public float dashCooldown = 1f;
    private bool isDashing = false;

    private float defaultGravityScale;

    void Start()
    {
        instance = this;
        defaultGravityScale = rb.gravityScale;
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        HandleDash();
    }

    void HandleMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = rb.linearVelocity;

        if (!isDashing)
            velocity.x = horizontalInput * walkSpeed;

        rb.linearVelocity = velocity;

        // Flip player sprite
        if (horizontalInput > 0 && swordRotator.transform.rotation.z == 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalInput < 0 && swordRotator.transform.rotation.z == 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void HandleJump()
    {
        if (GroundCheck())
        {
            numJumps = maxJumps;
        }

        if (Input.GetKeyDown(KeyCode.Space) && numJumps > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
            numJumps--;
        }
    }

    void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        rb.linearVelocity = new Vector2(transform.localScale.x * dashStrength, 0f);

        yield return new WaitForSeconds(0.15f);

        rb.gravityScale = defaultGravityScale;
        isDashing = false;
    }

    bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
    }
}
