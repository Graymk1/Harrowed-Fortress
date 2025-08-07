using TMPro;
using UnityEngine;

public class UiCon : MonoBehaviour
{
    [Header("Player HpBar")]
    public TMP_Text LightCur;

    void Update()
    {
        upLight();
    }
    void upLight()
    {
        LightCur.text = "Aether: " + LightCurrency.Instance.LightCurrencyCount;
    }
}
