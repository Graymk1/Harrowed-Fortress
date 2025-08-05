using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SwordRotator : MonoBehaviour
{
    

    public float hitTime = 2f;
    public float maxHittime = 2f;
    public GameObject sword;

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
            StartCoroutine(UseSword());
        }

        IEnumerator UseSword()
        {
            if (PlayerMovement.instance.transform.localScale.x == 1)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
                yield return new WaitForSeconds(1f);
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0));
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 180f));
                yield return new WaitForSeconds(1f);
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0));
            }



        }
        


        
    }
}
