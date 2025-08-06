using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float walkSpeed = 5f;
    Rigidbody2D rb;
    public LayerMask groundLayer;
    public Transform groundCheckPoint;
    public int damage;
    public float DamageCd;
    public float DamageTimer;
    bool faceRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FlipHere())
        {
            faceRight = !faceRight;
        }
        if (faceRight)
        {
            transform.localScale = new(1, 1, 1);
            rb.linearVelocity = new(walkSpeed, rb.linearVelocity.y);
        }
        else if (!faceRight)
        {
            transform.localScale = new(-1, 1, 1);
            rb.linearVelocity = new(-walkSpeed, rb.linearVelocity.y);
        }
        Debug.Log(FlipHere());
    }
    bool FlipHere()
    {
        return !Physics2D.Raycast(groundCheckPoint.position, Vector2.down, 0.7f, groundLayer) || Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, groundLayer);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        DamageTimer = 0;
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DamageTimer -= Time.deltaTime;
            if (DamageTimer < 0)
            {
                collision.gameObject.GetComponent<Health>().ChangeHealth(-damage);
                collision.gameObject.GetComponent<Animator>().SetTrigger("Hurt");
                DamageTimer = DamageCd;
            }
        }
    }
}
