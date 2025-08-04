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
        float horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime * walkSpeed;
        transform.Translate(horizontalInput, 0, 0);
    }
}
