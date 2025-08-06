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
    private float dashTimer;
    public float dashCooldown = 0.5f;
    private bool isDashing = false;
    public TrailRenderer trail;
    [Header("Player Hp")]
    public Health PlayerHp;

    private float defaultGravityScale;


    void Start()
    {
        instance = this;
        defaultGravityScale = rb.gravityScale;
        PlayerHp = GetComponent<Health>();
    }

    void Update()
    {
        //Debug.Log(GroundCheck());
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
        if (GroundCheck() && rb.linearVelocityY < 0.5f && rb.linearVelocityY > -0.5f)
        {
            numJumps = maxJumps;
        }

        if (Input.GetKeyDown(KeyCode.Space) && numJumps > 0 && rb.linearVelocityY < 0.5f && rb.linearVelocityY > -0.5f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
            numJumps--;
        }
    }

    void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && Time.time > dashTimer)
        {
            dashTimer = Time.time + dashCooldown;
            StartCoroutine(Dash());
            trail.emitting = true;
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        rb.linearVelocity = new Vector2(transform.localScale.x * dashStrength, 0f);
        LightCurrency.Instance.ChangeLightCurrency(-3);

        yield return new WaitForSeconds(0.15f);

        rb.gravityScale = defaultGravityScale;
        isDashing = false;
        trail.emitting = false;
    }

    bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
    }
}
