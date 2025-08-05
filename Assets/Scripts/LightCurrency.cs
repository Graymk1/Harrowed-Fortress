using UnityEngine;

public class LightCurrency : MonoBehaviour
{
    public static LightCurrency Instance;
    public int LightCurrencyCount;
    void Start()
    {
        Instance = this;
    }
    public void ChangeLightCurrency(int amount)
    {
        LightCurrencyCount += amount;
    }
}
