using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightCurrency : MonoBehaviour
{
    public static LightCurrency Instance;
    public int LightCurrencyCount;
    public float lightTimer;
    public GameObject val;
    public GameObject canv;
    public List<GameObject> lts;
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
        lts.Add(Instantiate(val, canv.transform));
        lts.LastOrDefault().transform.position = new(1250, 500 - (50 * (lts.Count - 1)), 0);
        lts.LastOrDefault().GetComponent<Minus>().ChangeVal(amount);
        lts.RemoveAll(item => item == null);
        if (LightCurrencyCount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
