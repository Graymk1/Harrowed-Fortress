using UnityEngine;
using System.Collections;

public class Enemy2Movement : MonoBehaviour
{
    public float Speed = 5f;
    public float ChaseDis;
    public Rigidbody2D rb;

    public int damage = 1;
    public float DamageCd = 0.2f;
    public float DamageTimer;
    public bool inkd = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.instance == null) { return; }
        Vector2 playerDir = PlayerMovement.instance.transform.position - transform.position;
        if (!inkd)
        {
            if (playerDir.magnitude < ChaseDis)
            {
                rb.linearVelocity = playerDir.normalized * Speed;
                if (playerDir.x > 0)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else if (playerDir.x < 0)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
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
    public IEnumerator KB(float kdTime)
    {
        inkd = true;

        // Get direction away from player
        Vector2 knockbackDir = (transform.position - PlayerMovement.instance.transform.position).normalized;

        // Apply force away from player (tweak multiplier as needed)
        rb.AddForce(knockbackDir *50, ForceMode2D.Impulse); // 100f = 50x + 5y merged
        Debug.Log("KB!!");
        yield return new WaitForSeconds(kdTime);

        inkd = false;
    }
}
