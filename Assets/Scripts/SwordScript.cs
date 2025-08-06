using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public static SwordScript instance;


    public float damage = 1f;
    private float damageTime;
    public float damageCD = 0.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && Time.time > damageTime)
        {
            damageTime = Time.time + damageCD;
            collision.GetComponent<Health>().ChangeHealth(-damage);
            collision.GetComponent<Animator>().SetTrigger("Hurt");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
