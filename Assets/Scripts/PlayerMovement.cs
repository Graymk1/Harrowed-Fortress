using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float jumpHeight = 16f;
    public Rigidbody2D rb;
    public GameObject swordRotator;

    public static PlayerMovement instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }
    public Transform groundCheckPoint;

    public LayerMask groundLayer;
    private float groundCheckRadius = 0.2f;
    public int maxJumps = 1;
    public int maxJump = 1;
    public int numJumps = 0;
    public int maxDashes = 1;
    public int numDashes = 1;

    public float dashStrength = 10f;
    public float dashCooldown = 1f;
    private bool isDashing = false;

    bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
    }

    // Update is called once per frame
    void Update()
    {




        float horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime * walkSpeed;
        transform.Translate(horizontalInput, 0, 0);

        if (horizontalInput > 0 && swordRotator.transform.rotation.z == 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalInput < 0 && swordRotator.transform.rotation.z == 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        float nextVelocityX = horizontalInput * walkSpeed;
        float nextVelocityY = rb.linearVelocityY;

        if (GroundCheck() && nextVelocityY <= 0)
        {
            numJumps = maxJumps;
        }

        if (Input.GetKeyDown(KeyCode.Space) && numJumps > 0 && nextVelocityY <= 0)
        {
            nextVelocityY = jumpHeight;
            numJumps -= 1;
        }
        if (isDashing == false)
        {
            rb.linearVelocity = new Vector2(nextVelocityX, nextVelocityY);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDashing = true;
            StartCoroutine(Dash());
        }

        IEnumerator Dash()
        {
            Debug.Log("Before: " + rb.linearVelocity);

            // Forcefully override x velocity
            rb.gravityScale = 0;    
            rb.AddForce(new(transform.localScale.x * dashStrength, 0), ForceMode2D.Impulse);
            
            rb.linearVelocityY = 0f;
            yield return new WaitForSeconds(.15f);
            rb.gravityScale = 3;
            Debug.Log("After: " + rb.linearVelocity);
            isDashing = false;
            
        }
    }

}
