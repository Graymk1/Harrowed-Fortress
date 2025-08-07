using System;
using System.Collections;
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
    bool inkd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inkd)
        {
            if (FlipHere())
            {
                faceRight = !faceRight;
                transform.localScale = new(-transform.localScale.x, transform.localScale.y, 1);
            }
            if (faceRight)
            {
                rb.linearVelocity = new(walkSpeed, rb.linearVelocity.y);
            }
            else if (!faceRight)
            {
                rb.linearVelocity = new(-walkSpeed, rb.linearVelocity.y);
            }
            Debug.Log(FlipHere());
        }
    }
    bool FlipHere()
    {
        return !Physics2D.Raycast(groundCheckPoint.position, Vector2.down, Math.Abs(transform.localScale.x) * 0.7f, groundLayer) || Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, groundLayer);
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
                collision.gameObject.GetComponent<LightCurrency>().ChangeLightCurrency(-damage);
                collision.gameObject.GetComponent<Animator>().SetTrigger("Hurt");
                DamageTimer = DamageCd;
            }
        }
    }
    public IEnumerator KD(float kdTime)
    {
        inkd = true;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(50, 5) * 20 * PlayerMovement.instance.transform.localScale.x);
        yield return new WaitForSeconds(kdTime);
        inkd = false;
    }
}
