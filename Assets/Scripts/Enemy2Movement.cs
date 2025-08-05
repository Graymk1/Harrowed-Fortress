using UnityEngine;

public class Enemy2Movement : MonoBehaviour
{
    public float fallSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,fallSpeed * Time.deltaTime * -1,0);
    }
}
