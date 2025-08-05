using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public static SwordScript instance;


    public float damage = 1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Health>().ChangeHealth(-damage);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
