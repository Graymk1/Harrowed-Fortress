using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public static SwordScript instance;


    public float damage = 1f;
    private float damageTime;
    public float damageCD = 0.5f;
    public float knockback = 10f;
    public AudioClip StabFlesh;

    public GameObject aether;

    public GameObject aether;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && Time.time > damageTime)
        {
            AudioPlay.Instance.PlayAudioOne(StabFlesh);
            damageTime = Time.time + damageCD;
            collision.GetComponent<Health>().ChangeHealth(-damage);
            collision.GetComponent<Animator>().SetTrigger("Hurt");

            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(50, 5) * 50 * PlayerMovement.instance.transform.localScale.x);
            Instantiate(aether, collision.transform.localPosition, gameObject.transform.localRotation);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
