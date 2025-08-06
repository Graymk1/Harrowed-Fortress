using TMPro;
using UnityEngine;

public class UiCon : MonoBehaviour
{
    [Header("Player HpBar")]
    public GameObject hpBar;
    public TMP_Text LightCur;

    void Update()
    {
        upHealth();
        upLight();
    }
    void upHealth()
    {
        if (PlayerMovement.instance == null) { hpBar.transform.localScale = new(0, 1, 1); return; }
        hpBar.transform.localScale = new(PlayerMovement.instance.PlayerHp.CurHealth / PlayerMovement.instance.PlayerHp.MaxHealth * 4.4125f, 1, 1);
    }
    void upLight()
    {
        LightCur.text = "Light Currecy: " + LightCurrency.Instance.LightCurrencyCount;
    }
}
