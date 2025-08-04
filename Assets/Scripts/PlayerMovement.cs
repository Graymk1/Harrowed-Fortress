using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal")*walkSpeed*Time.deltaTime;
        if (horizontalInput > 0 )
        {
            transform.position += Vector3.right;
        }
        else if (horizontalInput < 0)
        {
            transform.position += Vector3.left;
        }
    }
}
