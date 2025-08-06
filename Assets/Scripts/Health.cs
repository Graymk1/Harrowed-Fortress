using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject lightCurrency;

    public float MaxHealth;
    public float CurHealth;
    public void Start()
    {
        CurHealth = MaxHealth; //set start health
    }
    public void ChangeHealth(float health) //Add or subtract health points
    {
        CurHealth += health;
        if (CurHealth <= 0)
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("Enemy"))
            {
                Instantiate(lightCurrency,gameObject.transform.localPosition, gameObject.transform.localRotation);
            }
        }
    }

}
