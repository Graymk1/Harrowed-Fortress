using UnityEngine;

public class Enemy2Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float flySpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDir = PlayerMovement.instance.transform.position - transform.position;
        rb.linearVelocity = moveDir.normalized * flySpeed;
    }
}
