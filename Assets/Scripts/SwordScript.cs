using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float swordSpeed = 15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir = mousePos - (Vector2)transform.position;

        rb.linearVelocity = dir.normalized * swordSpeed;
    }
}
