using UnityEngine;

public class LightDropper : MonoBehaviour
{
    public static LightDropper instance;

    public float lightSpeed = 10f;
    public int amount;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LightCurrency.Instance.ChangeLightCurrency(amount);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerDir = PlayerMovement.instance.transform.position - transform.position;
        rb.linearVelocity = playerDir.normalized * lightSpeed;

    }
}
