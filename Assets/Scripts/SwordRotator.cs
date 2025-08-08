using System.Collections;
using UnityEngine;

public class SwordRotator : MonoBehaviour
{


    public GameObject sword;
    private bool debounce = true;
    public int SlashCostLightCurr;
    public AudioClip swordSwish;


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
            LightCurrency.Instance.ChangeLightCurrency(-SlashCostLightCurr);
            StartCoroutine(UseSword());
            sword.GetComponent<Animator>().SetBool("Hitting", true);
        }


        IEnumerator UseSword()
        {
            AudioPlay.Instance.PlayAudioOne(swordSwish);
            if (PlayerMovement.instance.transform.localScale.x == 1)
            {
                if (mouseDir.x > 0)
                {
                    PlayerMovement.instance.transform.localScale = new Vector3(1, 1, 1);
                    sword.SetActive(true);
                    transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    yield return new WaitForSeconds(0.25f);
                    transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0));
                    sword.SetActive(false);
                    debounce = true;
                    sword.GetComponent<Animator>().SetBool("Hitting", false);
                }
                else
                {
                    PlayerMovement.instance.transform.localScale = new Vector3(-1, 1, 1);
                    sword.SetActive(true);
                    transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 180f));
                    yield return new WaitForSeconds(0.25f);
                    transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0));
                    sword.SetActive(false);
                    debounce = true;
                    sword.GetComponent<Animator>().SetBool("Hitting", false);
                }


            }
            else
            {
                if (mouseDir.x > 0)
                {
                    PlayerMovement.instance.transform.localScale = new Vector3(1, 1, 1);
                    sword.SetActive(true);
                    transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    yield return new WaitForSeconds(0.25f);
                    transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0));
                    sword.SetActive(false);
                    debounce = true;
                    sword.GetComponent<Animator>().SetBool("Hitting", false);

                }
                else
                {
                    PlayerMovement.instance.transform.localScale = new Vector3(-1, 1, 1);
                    sword.SetActive(true);
                    transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 180f));
                    yield return new WaitForSeconds(0.25f);
                    transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0));
                    sword.SetActive(false);
                    debounce = true;
                    sword.GetComponent<Animator>().SetBool("Hitting", false);
                }
            }




        }




    }
}
