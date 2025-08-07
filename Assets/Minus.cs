using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Minus : MonoBehaviour
{
    public Color c = Color.red;
    void Update()
    {
        transform.Translate(0, 200 * Time.deltaTime, 0);
        c = new(c.r, c.g, c.b, c.a - Time.deltaTime * 1.5f);
        GetComponent<TextMeshProUGUI>().color = c;
        if (c.a < 0.005) { Destroy(gameObject); }
    }
    public void ChangeVal(int val)
    {
        if (val > 0)
        {
            c = Color.yellow;
        }
        GetComponent<TextMeshProUGUI>().text = val.ToString();
    }
}
