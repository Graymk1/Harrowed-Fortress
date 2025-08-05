using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SwordRotator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        Vector2 mouseDir = mousePos - (Vector2)transform.position;

        float angle = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            

            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0));
        }



        
    }
}
