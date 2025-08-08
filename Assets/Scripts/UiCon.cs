using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiCon : MonoBehaviour
{

    public static UiCon instance;
    [Header("Player HpBar")]
    public TMP_Text LightCur;

    [Header("Menu")]
    public GameObject restartMenu;
    public Button menuButton;
    public Button restartButton;

    private void Start()
    {
        instance = this;

        restartButton.onClick.AddListener(Restart);
        menuButton.onClick.AddListener(MainMenu);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    void Update()
    {
        upLight();
    }
    void upLight()
    {
        LightCur.text = "Aether: " + LightCurrency.Instance.LightCurrencyCount;
    }
}
