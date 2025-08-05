using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SwordRotator : MonoBehaviour
{
    

    public GameObject sword;
    public GameObject visualSword;
    private bool debounce = true;
    

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

        if (Input.GetKeyDown(KeyCode.Mouse0) && debounce)
        {
            debounce = false;
            print(mouseDir);
            StartCoroutine(UseSword());
        }

        IEnumerator UseSword()
        {
            if (PlayerMovement.instance.transform.localScale.x == 1)
            {
                
                sword.SetActive(true);
                visualSword.SetActive(false);
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
                yield return new WaitForSeconds(0.5f);
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0));
                sword.SetActive(false);
                visualSword.SetActive(true);
                debounce = true;
            }
            else
            {
                sword.SetActive(true);
                visualSword.SetActive(false);
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 180f));
                yield return new WaitForSeconds(0.5f);
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0));
                sword.SetActive(false);
                visualSword.SetActive(true);
                debounce = true;
            }



        }
        


        
    }
}
