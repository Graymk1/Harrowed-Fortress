using UnityEngine;

public class LightCurrency : MonoBehaviour
{
    public static LightCurrency Instance;
    public int LightCurrencyCount;
    public float lightTimer;
    void Start()
    {
        Instance = this;
    }
    void Update()
    {
        lightTimer += Time.deltaTime;
        if (lightTimer >= 2)
        {
            ChangeLightCurrency(-1);
            lightTimer = 0;
        }
    }

    public void ChangeLightCurrency(int amount)
    {
        LightCurrencyCount += amount;
        if (LightCurrencyCount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
