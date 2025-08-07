using UnityEngine;
using UnityEngine.SceneManagement;

public class TransportOrb : MonoBehaviour
{
    
    public float amplitude = 1f; // How high/low the wave goes
    public float frequency = 1f; // How fast the wave oscillates
    public float horizontalSpeed = 0f; // Speed of horizontal movement (optional)

    private Vector3 startPosition;

    public int nextScene = 0;

    void Start()
    {
        startPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level " + nextScene);
        }
    }

    void Update()
    {
        // Calculate the new Y position based on sine wave
        float newY = startPosition.y + amplitude * Mathf.Sin(Time.time * frequency);

        // Calculate the new X position if horizontal movement is enabled
        float newX = startPosition.x + horizontalSpeed * Time.deltaTime;

        // Update the object's position
        transform.position = new Vector3(newX, newY, startPosition.z);


    }
}
