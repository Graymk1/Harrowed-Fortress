using UnityEngine;

public class Enemy2Movement : MonoBehaviour
{
    public float Speed = 5f;
    public float ChaseDis;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerDir = PlayerMovement.instance.transform.position - transform.position;
        if (playerDir.magnitude < ChaseDis)
        {
            rb.linearVelocity = playerDir.normalized * Speed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
